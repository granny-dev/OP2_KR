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

        /// <summary>
        /// Initializes a new instance of the EmployeeOperations class.
        /// </summary>
        /// <param name="db">The database context.</param>
        public EmployeeOperations(IDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Performs a login operation for the given employee.
        /// </summary>
        /// <param name="emp">The employee object containing the name and password.</param>
        /// <returns>The role of the employee if the login is successful; otherwise, null.</returns>
        public string Login(Employee emp)
        {
            var cmd = $"SELECT Role FROM dbo.Employees WHERE Name = '{emp.Name}' AND Password = '{emp.Password}'";
            var result = db.ExecuteScalar<string>(cmd);
            return result;
        }
    }
}
    
    


