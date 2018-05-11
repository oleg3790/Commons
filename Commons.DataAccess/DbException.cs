using System;

namespace Commons.DataAccess
{
    [Obsolete("Intended for DbConnection, since DbConnection is no longer used, this is obsolete")]
    public class DbException
    {
        // Using my own exception class to split out what I need into seperate properties as I dont want to be hard coupling a reference to Oracle.DataAccess from other projects
        public string Message { get; set; } = string.Empty;
        public string Stacktrace { get; set; } = string.Empty;
        public int ErrorCode { get; set; } = 0;
        public string Query { get; set; } = string.Empty;
    }
}
