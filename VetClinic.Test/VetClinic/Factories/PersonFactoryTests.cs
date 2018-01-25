using Microsoft.VisualStudio.TestTools.UnitTesting;
using VetClinic.Data.Enums;
using VetClinic.Data.Models;
using VetClinic.Factories.Implemetations;

namespace VetClinic.Test.VetClinic.Factories
{
    [TestClass]
    public class PersonFactoryTests
    {
        [TestMethod]
        public void Constructor_Should_Create_New_Instance_Of_Factory_Class()
        {
            // Arrange & Act
            var personFactory = new PersonFactory();

            // Assert
            Assert.IsInstanceOfType(personFactory, typeof(PersonFactory));
        }

        [TestMethod]
        public void _Should_Create_New_Instance_Of_User_Class()
        {
            // Arrange
            var personFactory = new PersonFactory();

            // Act
            var user = personFactory.CreateUser("firstname", "lastname", "phone", "email");

            // Assert
            Assert.IsInstanceOfType(user, typeof(User));
        }

        [TestMethod]
        public void _Should_Create_New_Instance_Of_Employee_Class()
        {
            // Arrange
            var personFactory = new PersonFactory();

            // Act
            var employee = personFactory.CreateEmployee("firstname", "lastname", "phone", "email", RoleType.admin);

            // Assert
            Assert.IsInstanceOfType(employee, typeof(Employee));
        }
    }
}
