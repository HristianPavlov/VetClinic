﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using VetClinic.Commands.Contracts;
using VetClinic.Commands.Implementations;
using VetClinic.Common.ConsoleServices.Contracts;
using VetClinic.Data.Enums;
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
        public void CreateEmployee_Should_Call_PersonFactory()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var employeesRepoMock = new Mock<IEmployeeRepository>();
            var writerMock = new Mock<IWriter>();

            var employeeCommand = new EmployeeCommand(personFactoryMock.Object, employeesRepoMock.Object, writerMock.Object);


            var role = (RoleType)Enum.Parse(typeof(RoleType), "admin");

            // Act
            personFactoryMock.Setup(x => x.CreateEmployee("firstname", "lastname", "phone", "email", role));
            personFactoryMock.Object.CreateEmployee("firstname", "lastname", "phone", "email", role);

            // Assert
            personFactoryMock.Verify(x => x.CreateEmployee("firstname", "lastname", "phone", "email", role), Times.Once());
        }

        [TestMethod]
        public void DeleteEmployee_Should_Delete_Emplyoee_From_Db()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var employeesRepoMock = new Mock<IEmployeeRepository>();
            var writerMock = new Mock<IWriter>();

            var employeeCommand = new EmployeeCommand(personFactoryMock.Object, employeesRepoMock.Object, writerMock.Object);

            // Act
            employeesRepoMock.Setup(x => x.DeleteEmployee(It.IsAny<string>()));
            employeesRepoMock.Object.DeleteEmployee(It.IsAny<string>());

            // Assert
            employeesRepoMock.Verify(x => x.DeleteEmployee(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void ListEmployees_Should_Throw_Exception_If_Emplyoees_Count_Is_Zero()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var employeesRepoMock = new Mock<IEmployeeRepository>();
            var writerMock = new Mock<IWriter>();
            var employeeCommand = new EmployeeCommand(personFactoryMock.Object, employeesRepoMock.Object, writerMock.Object);


            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(()
                => employeesRepoMock.Object.Employees.Count == 0);
        }

        [TestMethod]
        public void SearchEmployeeByPhone_Should_Return_Emplyoee_PrintInfo_If_Found()
        {
            // Arrange
            var employeeCommandMock = new Mock<IEmployeeCommand>();

            // Act
            employeeCommandMock.Setup(x => x.SearchEmployeeByPhone(It.IsAny<IList<string>>()));
            employeeCommandMock.Object.SearchEmployeeByPhone(It.IsAny<IList<string>>());

            // Assert
            employeeCommandMock.Verify(x => x.SearchEmployeeByPhone(It.IsAny<IList<string>>()), Times.Once);

        }

    }
}
