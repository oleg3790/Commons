﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace Commons.DataAccess
{
    public class DConnection
    {
        private DatabaseType _databaseObjectType { get; set; }
        private string _connectionString { get; set; }

        /// <summary>
        /// Uses the global static parameter Type in DatabaseTypeManager to obtain the database object type (i.e. OracleConnection, SqlConnection, Odbc)
        /// </summary>
        /// <param name="connectionString"></param>
        public DConnection( string connectionString ) : this( connectionString, DatabaseTypeManager.Type )
        {
        }

        /// <summary>
        /// Used for connections to explicitly declared database object types
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="type">Type of database to connect to (i.e. OracleConnection, SqlConnection, Odbc)</param>
        public DConnection( string connectionString, DatabaseType type )
        {
            _databaseObjectType = type;
            _connectionString = connectionString;
        }        

        /// <summary>
        /// Tests a database connection by opening and closing the connection
        /// </summary>
        /// <returns>If the connection is valid, otherwise throws an exception</returns>
        public bool TestConnection()
        {
            try
            {
                using (IDbConnection connection = DatabaseTypeManager.GetDatabaseConnection(_databaseObjectType))
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();
                }

                return true;
            }
            catch (OracleException oe)
            {
                if (oe.Message == "ORA-01017: invalid username/password; logon denied")
                    throw new InvalidDbCredentialsException("Connection Error: The database username or password is incorrect", oe);
                else if (oe.Message == "Connection request timed out")
                    throw new DbConnectionTimeoutException("Connection Error: Database connection timed out, check your network and/or VPN");
                else
                    throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Reads data using a forward only connection
        /// </summary>
        /// <param name="query">Select query to fetch results for</param>
        /// <param name="parameters">Parameters of select query</param>
        /// <returns></returns>
        public DataTable LoadUsingReader( string query, params DParameter[] parameters )
        {
            return InitConnection<DataTable>((x) => 
            {
                try
                {
                    DataTable result = new DataTable();

                    using (IDataReader reader = x.ExecuteReader())
                    {
                        if (reader.FieldCount > 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                DataColumn column = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
                                result.Columns.Add(column);
                            }

                            object[] row = new object[reader.FieldCount];

                            while (reader.Read())
                            {
                                reader.GetValues(row);
                                result.LoadDataRow(row, true);
                            }
                        }
                    }

                    // Always return result, even if nothing was read so that there is no need to handle null
                    return result;
                }
                catch (Exception ex)
                {
                    LoggingHelper.WriteExceptionToLog(ex);
                    throw;
                }
                

            }, query, parameters);            
        }

        /// <summary>
        /// Binds data from the source to a dataset which returns the first instance of the table from that set
        /// </summary>
        /// <param name="query">Select query to fetch results for</param>
        /// <param name="parameters">Parameters of select query</param>
        /// <returns></returns>
        public DataTable LoadUsingAdapter( string query, params DParameter[] parameters )
        {
            return InitConnection<DataTable>((x) =>
            {
                DataSet resultSet = new DataSet();

                using (var adapter = DatabaseTypeManager.GetDataAdapter(_databaseObjectType, x))
                {
                    adapter.Fill(resultSet);
                }

                // Always return result, even if nothing was read so that there is no need to handle null
                return resultSet.Tables[0];

            }, query, parameters);
        }

        private T InitConnection<T>( Func<IDbCommand, object> executionFunction, string query, params DParameter[] parameters )
        {
            var result = (dynamic)null;

            try
            {
                using (IDbConnection connection = DatabaseTypeManager.GetDatabaseConnection(_databaseObjectType))
                {
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Connection.ConnectionString = _connectionString;
                        command.CommandText = query;
                        command.CommandTimeout = 30;

                        foreach (DParameter parameter in parameters)
                        {
                            IDbDataParameter dataParam = command.CreateParameter();
                            dataParam.ParameterName = parameter.Name;
                            dataParam.Value = parameter.Value;
                            dataParam.DbType = parameter.Type;
                            command.Parameters.Add(dataParam);                            
                        }

                        command.Connection.Open();
                        result = executionFunction(command);
                    }
                }

                return result;
            }
            catch (OracleException oe)
            {
                if (oe.Message == "ORA-01017: invalid username/password; logon denied")
                    throw new InvalidDbCredentialsException("Connection Error: The database username or password is incorrect", oe);
                else if (oe.Message == "Connection request timed out")
                    throw new DbConnectionTimeoutException("Connection Error: Database connection timed out, check your network and/or VPN");
                else
                {
                    LoggingHelper.LogDatabaseError(query, DParameterHelper.PrepareParameterLog(parameters), oe.StackTrace, oe.Message, oe.ErrorCode);
                    throw new DatabaseException("Oracle exception", oe);
                }                    
            }
            catch
            {
                throw;
            }
        }
    }
}
