using System;
using System.Collections.Generic;
using System.Data;

namespace XApp.Commons.DataAccess
{
    public class DParameter 
    {
        public string Name { get; set; }
        public object Value { get; set; }  
        public DbType Type { get; set; }            

        public DParameter( string name, object value, DbType type)
        {
            Name = name;
            SetValueType(value, type);                                    
        }

        public DParameter( string name, IEnumerable<object> values, DbType type)
        {
            Name = name;
        }

        private void SetValueType(object value, DbType type)
        {
            if (value.GetType() == typeof(bool))
            {
                Value = ((bool)value) ? 1 : 0;
                type = DbType.Decimal;
            }                
            else if (type == DbType.Guid && value.GetType() == typeof(Guid))
            {
                Value = ((Guid)value).ToString("N").ToUpper();
                Type = DbType.String;
            }
            else
            {
                Value = value;
                Type = type;
            }                
        }
    }
}
