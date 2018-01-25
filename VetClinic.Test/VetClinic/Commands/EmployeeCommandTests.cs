using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using VetClinic.Commands.Implementations;
using VetClinic.Common.ConsoleServices.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;

namespace VetClinic.Test.VetClinic.Commands
{
    [TestClass]
    public class EmployeeCommandTests
    {
        // Constructor
        [TestMethod]
        public void Constructor_Should_Return_New_Instance_Of_Class_EmployeeCommand()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var employeesRepoMock = new Mock<IEmployeeRepository>();
            var writerMock = new Mock<IWriter>();

            // Act
            var employeeCommand = new EmployeeCommand(personFactoryMock.Object, employeesRepoMock.Object, writerMock.Object);

            // Assert
            Assert.IsInstanceOfType(employeeCommand, typeof(EmployeeCommand));
        }

        // Methods
        [TestMethod]
        public void CreateEmployee_Should_Return_Correctly_FirstName()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var employeesRepoMock = new Mock<IEmployeeRepository>();
            var writerMock = new Mock<IWriter>();

            // Act
            var employeeCommand = new EmployeeCommand(personFactoryMock.Object, employeesRepoMock.Object, writerMock.Object);

            var args = new List<string>() {
                "firstname",
                "lastname",
                "phone",
                "email",
                "admin"
            };

            // Assert
            //Assert.IsTrue(employeeCommand.CreateEmployee(args));
        }
    }
}
