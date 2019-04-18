using XApp.Commons;
using XApp.Commons.Logging;
using XApp.Commons.DataAccess.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using log4net;

namespace XApp.Commons.DataAccess
{
    [Obsolete("Use AutoMapper (install via Nuget)  instead")]
    public static class DataMapper
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Maps data in a DataTable to a domain object collection
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sourceData"></param>
        /// <returns></returns>
        public static List<TResult> Map<TResult>(DataTable sourceData) where TResult : new()
        {
            List<TResult> resultList = new List<TResult>();

            foreach (DataRow row in sourceData.Rows)
            {
                TResult resultObject = new TResult();
                PropertyInfo[] properties = resultObject.GetType().GetProperties()
                    .Where(x => x.CustomAttributes
                        .Any(y => y.AttributeType
                            .Equals(typeof(DbColumnAttribute))))
                    .ToArray();

                foreach (PropertyInfo property in properties)
                {
                    var attribute = (DbColumnAttribute)property.GetCustomAttribute(typeof(DbColumnAttribute));

                    if (row[attribute.ColumnName] != DBNull.Value)
                    {
                        var rawValue = ConvertType(row[attribute.ColumnName], property, attribute);
                        property.SetValue(resultObject, rawValue);                        
                    }                      
                }
                resultList.Add(resultObject);
            }
            return resultList;
        }

        private static object ConvertType(object rawValue, PropertyInfo property, DbColumnAttribute attribute)
        {
            try
            {
                bool toNullable = Nullable.GetUnderlyingType(property.PropertyType) == rawValue.GetType();
                bool numericToBool = property.PropertyType.ContainsType(typeof(bool), typeof(bool?))
                    && rawValue.GetType().ContainsType(typeof(int), typeof(decimal), typeof(Int16));
                bool decimalToInt = property.PropertyType.ContainsType(typeof(int), typeof(int?))
                    && rawValue.GetType().ContainsType(typeof(decimal));
                bool toGuid = property.PropertyType.ContainsType(typeof(Guid), typeof(Guid?))
                    && rawValue.GetType() == typeof(byte[]);

                if (toNullable)
                    return rawValue;
                else if (numericToBool)
                    rawValue = (Convert.ToInt16(rawValue) == 1) ? true : false;
                else if (decimalToInt)
                    rawValue = Convert.ToInt32(rawValue);                
                else if (toGuid)
                    rawValue = new Guid(HexHelper.ToHexString((byte[])rawValue));
                else if (attribute.ColumnConversionHint == DbColumnAttribute.ColumnConversionHints.ToListByPipe)
                    rawValue = rawValue.ToString().Split('|').ToList();
                else if (rawValue.GetType() != property.GetType())
                    rawValue = Convert.ChangeType(rawValue, property.PropertyType);

                return rawValue;
            }
            catch (InvalidCastException ex)
            {
                log.Debug(string.Format("Type Conversion Exception:\n\tRaw Value:{0}(Type:{1})\n\tProperty:{2}(Type:{3})\nSTACKTRACE:\n{4}",
                    rawValue.ToString(),
                    rawValue.GetType(),
                    property.Name,
                    property.PropertyType.ToString(),
                    ex.StackTrace));
                throw;
            }
            catch (Exception ex)
            {
                log.Error($"Message => {ex.Message}\nStacktrace => {ex.StackTrace}");
                throw;
            }
        }
    }
}
