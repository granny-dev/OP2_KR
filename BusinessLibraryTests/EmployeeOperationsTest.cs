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
            mockDb = new Mock<IDbContext>();
            employeeOperations = new EmployeeOperations(mockDb.Object);
        }


        [TestMethod]
        public void Login_Test()
        {
            // Arrange
            var expectedRole = "Developer";
            var emp = new Employee { Name = "John", Password = "password" };

            mockDb.Setup(x => x.ExecuteScalar<string>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(expectedRole);

            // Act
            var actualRole = employeeOperations.Login(emp);

            // Assert
            Assert.AreEqual(expectedRole, actualRole);
            mockDb.Verify(x => x.ExecuteScalar<string>(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }
    }
}
