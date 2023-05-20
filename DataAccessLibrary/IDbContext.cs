using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IDbContext
    {
        /// <summary>
        /// Executes the SQL query and returns a single value of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="parameters">Optional parameters for the SQL query.</param>
        /// <returns>The single value of the specified type.</returns>
        T ExecuteScalar<T>(string sql, object parameters = null);

        /// <summary>
        /// Executes the stored procedure and returns a single value of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="sql">The stored procedure name to execute.</param>
        /// <param name="parameters">Optional parameters for the stored procedure.</param>
        /// <returns>The single value of the specified type.</returns>
        T ExecuteProcedure<T>(string sql, object parameters = null);

        /// <summary>
        /// Executes the SQL query and returns a list of results of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the results to return.</typeparam>
        /// <param name="sql">The SQL query to execute.</param>
        /// <param name="parameters">Optional parameters for the SQL query.</param>
        /// <returns>A list of results of the specified type.</returns>
        List<T> ExecuteQuery<T>(string sql, object parameters = null);
    }
}
