using BusinessLibrary;
using DataAccessLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibraryTests
{
    [TestClass]
    public class EmployeeOperationsTest
    {
        private Mock<IDbContext> mockDb;
        private EmployeeOperations employeeOperations;

        [TestInitialize]
        public void Setup()
        {
            // Setting up the mock objects and initializing the class under test
            mockDb = new Mock<IDbContext>();
            employeeOperations = new EmployeeOperations(mockDb.Object);
        }


        [TestMethod]
        public void Login_Test()
        {
            // Arrange
            var expectedRole = "Developer";
            var emp = new Employee { Name = "John", Password = "password" };

            // Setting up the mock behavior for the database context's ExecuteScalar method
            mockDb.Setup(x => x.ExecuteScalar<string>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(expectedRole);

            // Act
            var actualRole = employeeOperations.Login(emp);

            // Assert
            Assert.AreEqual(expectedRole, actualRole);

            // Verifying that the ExecuteScalar method was called exactly once
            mockDb.Verify(x => x.ExecuteScalar<string>(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }
    }
}
