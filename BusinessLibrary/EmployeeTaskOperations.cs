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

        /// <summary>
        /// Initializes a new instance of the EmployeeTaskOperations class.
        /// </summary>
        /// <param name="db">The database context.</param>
        public EmployeeTaskOperations(IDbContext db)
        {

            this.db = db;
        }

        /// <summary>
        /// Deletes a task with the specified ID from the TasksTable.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>True if the task is deleted successfully; otherwise, false.</returns>
        public bool Delete(int id)
        {
            return db.ExecuteScalar<int>("delete from dbo.TasksTable where Id = @id", new { id }) == 1;
        }

        /// <summary>
        /// Retrieves all employee tasks from the TasksTable.
        /// </summary>
        /// <returns>A list of EmployeeTask objects representing the tasks.</returns>
        public List<EmployeeTask> GetAll()
        {
            return db.ExecuteQuery<EmployeeTask>("select Id, Title, Status, Priority, Author, Executor, Estimate, Description from dbo.TasksTable");
        }

        /// <summary>
        /// Inserts a new task into the TasksTable.
        /// </summary>
        /// <param name="task">The EmployeeTask object representing the task to insert.</param>
        /// <returns>The inserted EmployeeTask object.</returns>
        public EmployeeTask Insert(EmployeeTask task)
        {
            db.ExecuteProcedure<int>("dbo.TasksTable_AddTask", new { task.Title, task.Status, task.Priority, task.Author, task.Executor, task.Estimate, task.Description });

            return task;            
        }

        /// <summary>
        /// Updates an existing task in the TasksTable.
        /// </summary>
        /// <param name="task">The EmployeeTask object representing the task to update.</param>
        /// <returns>The updated EmployeeTask object.</returns>
        public EmployeeTask Update(EmployeeTask task)
        {
            db.ExecuteProcedure<int>("dbo.TasksTable_UpdateTask", new { task.Title, task.Status, task.Priority, task.Author, task.Executor, task.Estimate, task.Description });

            return task;
        }

        /// <summary>
        /// Saves a task based on its state (Added or Changed).
        /// </summary>
        /// <param name="task">The EmployeeTask object representing the task to save.</param>
        /// <param name="state">The state of the task (Added or Changed).</param>
        /// <returns>The saved EmployeeTask object.</returns>
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
