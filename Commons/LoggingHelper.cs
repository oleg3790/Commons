using System;
using System.Configuration;
using System.IO;

namespace Commons
{
    public static class LoggingHelper
    {
        private readonly static string logDir = ConfigurationSettings.AppSettings.Get("logfile");

        public static void WriteToLog(string stringToLog)
        {            
            string fileoutput = string.Format("\n\n\n{0}\n{1}",DateTime.Now.ToString(),stringToLog);
            File.AppendAllText(logDir, fileoutput);                          
        }

        public static void WriteExceptionToLog(Exception e)
        {
            string fileoutput = string.Format("\n\n\n{0}\nMESSAGE: {1}\nSTACKTRACE:\n{2}\n", DateTime.Now.ToString(), e.Message, e.StackTrace);
            File.AppendAllText(logDir, fileoutput);
        }

        public static void LogDatabaseError( string query, Tuple<string, object, string>[] parameters, string stackTrace, string message, int errorCode )
        {
            string fileOutput = string.Format("\n\n\nLOGTIME: {0}\nERRORCODE: {1}\nMESSAGE: {2}\nSTACKTRACE:\n{3}\n\nQUERY:\n{4}\n\nPARAMETERS:\n",
                DateTime.Now.ToString(), errorCode, message, stackTrace, query);

            foreach (Tuple<string, object, string> x in parameters)
                fileOutput = fileOutput + string.Format("\tn:{0} v:{1} t:{2}\n", x.Item1, x.Item2, x.Item3);

            File.AppendAllText(logDir, fileOutput);
        }        
    }
}

