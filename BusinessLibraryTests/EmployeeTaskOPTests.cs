using BusinessLibrary;
using Dapper;
using DataAccessLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibraryTests
{
    [TestClass]
    public class EmployeeTaskOPTests
    {
        private Mock<IDbContext> mockDb;
        private EmployeeTaskOperations employeeTaskOperations;

        [TestInitialize]
        public void Setup()
        {
            // Setting up the mock objects and initializing the class under test
            mockDb = new Mock<IDbContext>();
            employeeTaskOperations = new EmployeeTaskOperations(mockDb.Object);
        }

        [TestMethod]
        public void Delete_Test()
        {
            // Arrange
            int expectedId = 1;

            // Setting up the mock behavior for the database context's ExecuteScalar method
            mockDb.Setup(
                x => x.ExecuteScalar<int>(
                It.Is<string>(sql => sql == "delete from dbo.TasksTable where Id = @id"),
                It.IsAny<object>()))
                .Returns(1);

            // Act
            bool result = employeeTaskOperations.Delete(expectedId);

            // Assert
            Assert.IsTrue(result);
            mockDb.VerifyAll();
        }

        [TestMethod]
        public void GetAll_Test()
        {
            //Arrange
            List<EmployeeTask> expectedTasks = new List<EmployeeTask> {  

                 // Creating a list of expected tasks
                new EmployeeTask
                {
                    Title = "Create",
                    Status = "New",
                    Priority = "Normal",
                    Author = "Mike",
                    Executor = "Sam",
                    Estimate = "20.05.2023",
                    Description = "Description",

                },
                new EmployeeTask
                {
                    Title = "Read",
                    Status = "New",
                    Priority = "Normal",
                    Author = "Mike",
                    Executor = "Mark",
                    Estimate = "25.05.2023",
                    Description = "Description",

                },
                new EmployeeTask
                {
                    Title = "Update",
                    Status = "New",
                    Priority = "Normal",
                    Author = "Mike",
                    Executor = "James",
                    Estimate = "05.06.2023",
                    Description = "Description",

                },
                new EmployeeTask
                {
                    Title = "Delete",
                    Status = "New",
                    Priority = "Normal",
                    Author = "Mike",
                    Executor = "Dan",
                    Estimate = "10.06.2023",
                    Description = "Description"

                } };

            // Setting up the mock behavior for the database context's ExecuteQuery method
            mockDb.Setup(x => x.ExecuteQuery<EmployeeTask>("select Id, Title, Status, Priority, Author, Executor, Estimate, Description from dbo.TasksTable", 
                It.IsAny<object>()))
                .Returns(expectedTasks);

            //Act
            List<EmployeeTask> actualTasks = employeeTaskOperations.GetAll();

            //Assert
            CollectionAssert.AreEqual(expectedTasks, actualTasks);
            mockDb.VerifyAll();
        }

        [TestMethod]
        public void Insert_Test()
        {
            //Arrange
            EmployeeTask expectedTask = new EmployeeTask {
                Title = "Test",
                Status = "New",
                Priority = "Normal",
                Author = "Nick",
                Executor = "James",
                Estimate = "30.05.2023",
                Description = "Description"
            };

            // Setting up the mock behavior for the database context's ExecuteProcedure method
            mockDb.Setup(x => x.ExecuteProcedure<int>("dbo.TasksTable_AddTask", It.IsAny<object>()))
                .Returns(1);

            // Act
            EmployeeTask actualTask = employeeTaskOperations.Insert(expectedTask);

            //Assert
            Assert.AreEqual(expectedTask, actualTask);
            mockDb.VerifyAll();
        }

        [TestMethod]
        public void Update_Test()
        {
            //Arrange
            EmployeeTask expectedTask = new EmployeeTask
            {
                Title = "Create",
                Status = "InProgress",
                Priority = "Normal",
                Author = "Mike",
                Executor = "Sam",
                Estimate = "20.05.2023",
                Description = "Description"
            };

            // Setting up the mock behavior for the database context's ExecuteProcedure method
            mockDb.Setup(x => x.ExecuteProcedure<int>("dbo.TasksTable_UpdateTask", It.IsAny<object>()))
                .Returns(1);

            //Act
            EmployeeTask actualTask = employeeTaskOperations.Update(expectedTask);

            //Assert
            Assert.AreEqual(expectedTask, actualTask);
            mockDb.VerifyAll();
        }

        [TestMethod]
        public void SaveStateAdded_Test()
        {
            //Arrange
            EmployeeTask expectedTask = new EmployeeTask
            {
                Title = "Test",
                Status = "New",
                Priority = "Normal",
                Author = "Nick",
                Executor = "James",
                Estimate = "30.05.2023",
                Description = "Description"
            };
            TaskState state = TaskState.Added;

            // Setting up the mock behavior for the database context's ExecuteProcedure method
            mockDb.Setup(x => x.ExecuteProcedure<int>("dbo.TasksTable_AddTask", It.IsAny<object>()))
                .Returns(1);

            //Act
            EmployeeTask actualTask = employeeTaskOperations.Save(expectedTask, state);

            //Assert
            Assert.AreEqual(expectedTask, actualTask);
            mockDb.VerifyAll();
        }

        [TestMethod]
        public void SaveStateChanged_Test()
        {
            //Arrange
            EmployeeTask expectedTask = new EmployeeTask
            {
                Title = "Create",
                Status = "InProgress",
                Priority = "Normal",
                Author = "Mike",
                Executor = "Sam",
                Estimate = "20.05.2023",
                Description = "Description"
            };
            TaskState state = TaskState.Changed;

            // Setting up the mock behavior for the database context's ExecuteProcedure method
            mockDb.Setup(x => x.ExecuteProcedure<int>("dbo.TasksTable_UpdateTask", It.IsAny<object>()))
                .Returns(1);

            //Act
            EmployeeTask actualTask = employeeTaskOperations.Save(expectedTask, state);

            //Assert
            Assert.AreEqual(expectedTask, actualTask);
            mockDb.VerifyAll();
        }
    }
}
