using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons.DataAccess
{
    /// <summary>
    /// Provides basic helper functions for the DParameter type
    /// </summary>
    public static class DParameterHelper
    {
        internal static Tuple<string, object, string>[] PrepareParameterLog( DParameter[] parameters )
        {
            Tuple<string, object, string>[] result = new Tuple<string, object, string>[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                result[i] = new Tuple<string, object, string>(parameters[i].Name, parameters[i].Value, parameters[i].Type.ToString());
            }

            return result;
        }

        public static List<DParameter> BuildInParameters<T>( ref string query, string parameterName, List<T> parameterValues )
        {
            List<DParameter> result = new List<DParameter>();
            List<string> newParamNames = new List<string>();
            int paramNameNum = 1;
            
            foreach(T value in parameterValues)
            {
                var newParamName = string.Format(":{0}{1}", parameterName, paramNameNum++);
                result.Add(new DParameter(newParamName.Replace(":", string.Empty), value, DbTypeHelper.GetDbType(value)));
                newParamNames.Add(newParamName);
            }

            query = query.Replace(string.Format(":{0}", parameterName), newParamNames.Aggregate(( x, y ) => string.Format("{0},{1}", x, y)));
            return result;
        }        
    }
}
