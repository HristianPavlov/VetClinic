using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
