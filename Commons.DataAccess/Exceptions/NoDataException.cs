using System;

namespace Commons.DataAccess.Exceptions
{
    public class NoDataException : Exception
    {
        public NoDataException( string message = "No data found" ) : base(message)
        {

        }
    }
}
