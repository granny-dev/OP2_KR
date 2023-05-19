using Dapper;
using DataAccessLibrary;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public class EmployeeOperations
    {
        IDbContext db;

        public EmployeeOperations(IDbContext db)
        {
            this.db = db;
        }

        public string Login(Employee emp)
        {
            var cmd = $"SELECT Role FROM dbo.Employees WHERE Name = '{emp.Name}' AND Password = '{emp.Password}'";
            var result = db.ExecuteScalar<string>(cmd);
            return result;
        }
    }
}
    
    


