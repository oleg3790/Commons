using Commons;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace Commons.DataAccess
{
    /// <summary>
    /// Used to make/build connections out to a database
    /// </summary>
    [Obsolete("Use DConnection as this was a prehistoric way of connecting")]
    public static class DbConnection
    {         
        /// <summary>
        /// Constructs a connection string using the UN/PW passed
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="DB"></param>
        /// <returns></returns>
        private static string BuildConnectionString( string username, string password, DatabaseConnectionType_Old DB )
        {
            string connectionString = string.Empty;

            switch (DB)
            {
                case DatabaseConnectionType_Old.ProdDatabase1:
                    connectionString = ConfigurationSettings.AppSettings.Get("OraDb1");
                    break;
                case DatabaseConnectionType_Old.ProdDatabase2:
                    connectionString = ConfigurationSettings.AppSettings.Get("OraDb2");
                    break;
                case DatabaseConnectionType_Old.DevDatabase1:
                    connectionString = ConfigurationSettings.AppSettings.Get("OraDevDb1");
                    break;
                case DatabaseConnectionType_Old.DevDatabase2:
                    connectionString = ConfigurationSettings.AppSettings.Get("OraDevDb2");
                    break;
                default:
                    throw new Exception("Cannot determine database connection string");
            }

            connectionString = connectionString.Replace("dbuser", username).Replace("dbpw", password);
            return connectionString;
        }

        public static DbResult<DataTable> RunQuery(string query, DatabaseConnectionType_Old connDB)
        {
            DbResult<DataTable> dbResult = new DbResult<DataTable>();
            DataSet dataSet = new DataSet();            

            try
            {
                using (OracleConnection conn = new OracleConnection(BuildConnectionString("", "", connDB)))
                {
                    conn.Open();                    
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.CommandTimeout = 45;
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dataSet);
                    }                       
                }
                dbResult.ResultData = dataSet.Tables[0];
                dbResult.IsError = false;
            }
            catch (OracleException e)
            {
                dbResult.Exception.Message = e.Message;
                dbResult.Exception.Stacktrace = e.StackTrace;
                dbResult.Exception.ErrorCode = e.ErrorCode;
                dbResult.Exception.Query = query;
                dbResult.IsError = true;
            }

            return dbResult;
        }
    }
        
}
