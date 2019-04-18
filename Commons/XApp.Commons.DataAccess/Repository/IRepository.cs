using System.Collections.Generic;
using System.Data;

namespace XApp.Commons.DataAccess.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Used to retrieve data as a DataTable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connectionString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        DataTable Get(string query, string connectionString, params DParameter[] parameters);

        /// <summary>
        /// Used to fetch the first column of a DataTable as a collection of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="connectionString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        ICollection<T> GetFirstColumnAsCollection<T>(string query, string connectionString, params DParameter[] parameters) where T : class;        
    }
}
