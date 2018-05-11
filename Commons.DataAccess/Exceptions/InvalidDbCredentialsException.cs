using System;

namespace Commons.DataAccess
{
    public class InvalidDbCredentialsException : Exception
    {
        public InvalidDbCredentialsException( string message ) : base( message )
        {

        }

        public InvalidDbCredentialsException( string message, Exception ex ) : base( message, ex )
        {

        }
    }
}
