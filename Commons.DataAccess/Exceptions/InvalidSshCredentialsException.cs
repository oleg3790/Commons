using System;

namespace Commons.DataAccess
{
    public class InvalidSshCredentialsException : Exception
    {
        public InvalidSshCredentialsException( string message ) : base( message )
        {

        }

        public InvalidSshCredentialsException( string message, Exception ex ) : base( message, ex )
        {

        }
    }
}
