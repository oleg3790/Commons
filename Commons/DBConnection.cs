using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace Commons
{
    public static class DBConnection
    {         
        public enum Database
        {
            DB1,
            DB2
        }

        public static string DBexception { get; set; }
        private static OracleConnection conn { get; set; }

        public static void ClearAllDBPools()
        {
            try
            {
                OracleConnection.ClearAllPools();
            }
            catch
            {
                //Do nothing
            }
        }
         
        public static bool Validate(Database connDB, string user, string pw)
        {
            try
            {
                using (conn = new OracleConnection(DBCredUpdate(user, pw, connDB)))
                {
                    //Log connection string
                    //LoggingHelper.writeToLog("Validation Connection: " + conn.ConnectionString);
                    conn.Open();
                }                
                    
                return true;
            }
            catch (OracleException e)
            {
                //Write errors to log file
                LoggingHelper.WriteToLog(string.Format("Code Error: {0}\n{1}\nMessage: {2}\nUSER:\n{3}", e.ErrorCode, e.Message, e.StackTrace, user));

                return false;
            }
        }

        private static string DBCredUpdate(string username, string password, Database DB)
        {
            string connectionString = string.Empty;
            if (DB == Database.DB1)
                connectionString = ConfigurationSettings.AppSettings.Get("OraDb1");
            else
                connectionString = ConfigurationSettings.AppSettings.Get("OraDb2");

            //Set the DB connection user and pw to the one passed through this method
            connectionString = connectionString.Replace("dbuser",username).Replace("dbpw",password);
            return connectionString;
        }

        public static DataTable RunQuery(string query, Database connDB)
        {
            DataSet dataSet = new DataSet();
            DBexception = null;

            try
            {
                using (conn = new OracleConnection(DBCredUpdate(RegistryHandler.dbUsername, RegistryHandler.dbPassword, connDB)))
                {
                    //Log connection string
                    //LoggingHelper.writeToLog("runQuery Connection: " + conn.ConnectionString);
                    conn.Open();                    
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.CommandTimeout = 45;
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dataSet);
                    }                       
                }
                DBexception = string.Empty;
            }
            catch (OracleException e)
            {
                DBexception = e.Message;

                //Write errors to log file
                LoggingHelper.WriteToLog(string.Format("Code Error: {0}\n{1}\nMessage: {2}\n***QUERY***\n{3}", e.ErrorCode, e.Message, e.StackTrace, query));
            }

            return dataSet.Tables[0];
        }        
    }
        
}
