using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ModelLibrary;
using System.Configuration;

namespace BusinessLibrary
{
    
    public class EmployeeTaskOperations
    {

        IDbContext db;

        public EmployeeTaskOperations(IDbContext db)
        {

            this.db = db;
        }

        public bool Delete(int id)
        {
            return db.ExecuteScalar<int>("delete from dbo.TasksTable where Id = @id", new { id }) == 1;
        }

        public List<EmployeeTask> GetAll()
        {
            return db.ExecuteQuery<EmployeeTask>("select Id, Title, Status, Priority, Author, Executor, Estimate, Description from dbo.TasksTable");
        }

        public EmployeeTask Insert(EmployeeTask task)
        {
            db.ExecuteProcedure<int>("dbo.TasksTable_AddTask", new { task.Title, task.Status, task.Priority, task.Author, task.Executor, task.Estimate, task.Description });

            return task;            
        }

        public EmployeeTask Update(EmployeeTask task)
        {
            db.ExecuteProcedure<int>("dbo.TasksTable_UpdateTask", new { task.Title, task.Status, task.Priority, task.Author, task.Executor, task.Estimate, task.Description });

            return task;
        }

        public EmployeeTask Save(EmployeeTask task, TaskState state)
        {
            if (state == TaskState.Added)
            {
                task = Insert(task);
            }
            else if (state == TaskState.Changed)
            {
                task = Update(task);
            }
            return task;
        }
    }
}
