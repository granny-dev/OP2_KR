using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLibrary
{
    public class DbContext : IDbContext  //Implements interface
    {
        private readonly IDbConnection connection;

        public DbContext()
        {
            connection = new SqlConnection(Config.ConnectionString);
        }

        public List<T> ExecuteQuery<T>(string sql, object parameters)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection.Query<T>(sql, parameters, commandType: CommandType.Text).ToList();
        }

        public T ExecuteProcedure<T>(string sql, object parameters = null)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection.ExecuteScalar<T>(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        public T ExecuteScalar<T>(string sql, object parameters)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection.ExecuteScalar<T>(sql, parameters, commandType: CommandType.Text);
        }
    }
}
