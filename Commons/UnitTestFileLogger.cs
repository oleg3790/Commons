using System.IO;

namespace Commons
{
    public static class UnitTestFileLogger
    {
        public static void WriteToLog( string stringToLog, string logFilename )
        {            
            var logfile = string.Format(@"C:\Users\Public\{0}.log", logFilename);
            string fileoutput = string.Format("{0}\n\n\n", stringToLog);
            
            File.AppendAllText(logfile,fileoutput);                          
        }

        public static void DeleteFile( string filename )
        {
            File.Delete(string.Format(@"C:\Users\Public\{0}.log", filename));
        }
    }
}
