using System;

namespace Commons.DataAccess
{
    public class DbConnectionTimeoutException : Exception
    {
        public DbConnectionTimeoutException( string message) : base( message )
        {
        }

        public DbConnectionTimeoutException( string message, Exception ex ) : base( message, ex )
        {
        }
    }
}
