using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IDbContext
    {
        T ExecuteScalar<T>(string sql, object parameters = null);

        T ExecuteProcedure<T>(string sql, object parameters = null);

        List<T> ExecuteQuery<T>(string sql, object parameters = null);
    }
}
