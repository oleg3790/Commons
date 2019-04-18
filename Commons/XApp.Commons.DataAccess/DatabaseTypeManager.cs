using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace XApp.Commons.DataAccess
{
    public enum DatabaseType
    {
        OracleSql = 0,
        SqlServer = 1,
        Odbc = 2,
        Unknown = 3
    }

    public static class DatabaseTypeManager
    {
        public static DatabaseType Type { get; set; } = DatabaseType.Unknown;

        internal static IDbConnection GetDatabaseConnection(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.OracleSql:
                    return new OracleConnection();
                case DatabaseType.SqlServer:
                    return new SqlConnection();
                case DatabaseType.Odbc:
                    return new OdbcConnection();
                case DatabaseType.Unknown:
                default:
                    throw new Exception("Define the database type before trying to return an IDbConnection");
            }
        }

        internal static IDbCommand GetCommandType(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.OracleSql:
                    return new OracleCommand();
                case DatabaseType.SqlServer:
                    return new SqlCommand();
                case DatabaseType.Odbc:
                    return new OdbcCommand();
                case DatabaseType.Unknown:
                default:
                    throw new Exception("Define the database type before trying to return an IDbCommand");
            }
        }

        internal static DbDataAdapter GetDataAdapter(DatabaseType type, IDbCommand command)
        {
            switch (type)
            {
                case DatabaseType.OracleSql:
                    return new OracleDataAdapter(RemapCommand<OracleCommand>(command));
                case DatabaseType.SqlServer:
                    return new SqlDataAdapter(RemapCommand<SqlCommand>(command));
                case DatabaseType.Odbc:
                    return new OdbcDataAdapter(RemapCommand<OdbcCommand>(command));
                case DatabaseType.Unknown:
                default:
                    throw new Exception("Define the database type before trying to return an IDbDataAdapter");
            }
        }

        internal static T RemapCommand<T>(IDbCommand command) where T : IDbCommand, new()
        {
            T newCommand = new T()
            {
                CommandText = command.CommandText,
                CommandType = command.CommandType
            };

            foreach (var x in command.Parameters)
                newCommand.Parameters.Add(x);

            return newCommand;
        }

        internal static IDbDataParameter GetDataParameterType(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.OracleSql:
                    return new OracleParameter();
                case DatabaseType.SqlServer:
                    return new SqlParameter();
                case DatabaseType.Odbc:
                    return new OdbcParameter();
                case DatabaseType.Unknown:
                default:
                    throw new Exception("Define the database type before trying to return an IDbDataAdapter");
            }
        }
    }
}
