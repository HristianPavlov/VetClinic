using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using VetClinic.Data.Contracts;
using VetClinic.Data.Repositories.Implementations;

namespace VetClinic.Test.VetClinic.Data.Repositories
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        [TestMethod]
        public void Constructor_Should_Return_New_Instance()
        {
            // Arrange & Act
            var employeeRepository = new EmployeeRepository();

            // Assert
            Assert.IsInstanceOfType(employeeRepository, typeof(EmployeeRepository));
        }

        [TestMethod]
        public void Constructor_Should_Initialize_EmployeeList()
        {
            // Arrange & Act
            var employeeRepository = new EmployeeRepository();

            // Assert
            Assert.IsNotNull(employeeRepository.Employees);
        }

        [TestMethod]
        public void CreateEmployee_Should_Add_Employee_To_EmployeeList()
        {
            // Arrange
            var employeeRepository = new EmployeeRepository();
            var employee = new Mock<IEmployee>();

            // Act
            employeeRepository.employees.Add(employee.Object);
            var expectedEmployee = employeeRepository.employees.SingleOrDefault();

            // Assert
            Assert.IsNotNull(employeeRepository.employees);
            Assert.IsTrue(employeeRepository.employees.Count == 1);
            Assert.IsInstanceOfType(expectedEmployee, typeof(IEmployee));
        }

        [TestMethod]
        public void DeleteEmployee_Should_Delete_Employee_From_EmployeeList()
        {
            // Arrange
            var employeeRepository = new EmployeeRepository();
            var employee = new Mock<IEmployee>();

            // Act
            employeeRepository.employees.Add(employee.Object);
            employeeRepository.employees.Remove(employee.Object);
            var expectedEmployee = employeeRepository.employees.SingleOrDefault();

            // Assert
            Assert.IsTrue(employeeRepository.employees.Count == 0);
            Assert.IsNull(expectedEmployee);
        }
    }
}
