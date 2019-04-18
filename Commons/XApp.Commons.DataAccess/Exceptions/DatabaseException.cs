using System;

namespace XApp.Commons.DataAccess
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) 
            : base(message)
        { }

        public DatabaseException(string message, Exception ex) 
            : base(message, ex)
        { }
    }
}
