using Oracle.ManagedDataAccess.Client;
using System;

namespace Commons.DataAccess
{
    [Obsolete("Intended for DbConnection, since DbConnection is no longer used, this is obsolete")]
    public class DbResult<T>
    {
        public bool IsError { get; set; }
        public DbException Exception { get; set; } = new DbException();
        public T ResultData { get; set; }
    }
}
