using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace XApp.Commons.DataAccess.Repository
{
    public class Repository : IRepository
    {
        public DataTable Get(string query, string connectionString, params DParameter[] parameters)
        {
            return new DConnection(connectionString)
                .LoadUsingReader(query, parameters);
        }

        public ICollection<T> GetFirstColumnAsCollection<T>(string query, string connectionString, params DParameter[] parameters) where T : class
        {
            return Get(query, connectionString, parameters)
                .AsEnumerable()
                .Select(x => x[0] as T).ToList();
        }
    }
}
