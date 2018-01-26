using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VetClinic.Data.Enums;
using VetClinic.Data.Models;

namespace VetClinic.Test.VetClinic.Data.Models
{
    [TestClass]
    public class EmployeeTests
    {
        // Constructor
        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_FirstName_Is_Null()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Employee(null, "lastName", "phone", "email", RoleType.admin));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_FirstName_Is_Empty()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Employee(string.Empty, "lastName", "phone", "email", RoleType.admin));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_LastName_Is_Null()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Employee("firstName", null, "phone", "email", RoleType.admin));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_LastName_Is_Empty()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Employee("firstName", string.Empty, "phone", "email", RoleType.admin));
        }

        [TestMethod]
        public void Constructor_Should_Create_New_Instance_Of_Class_Employee()
        {
            // Arrange & Act
            var e = new Employee("firstName", "lastName", "phone", "email", RoleType.admin);

            // Assert
            Assert.IsNotNull(e);
            Assert.IsInstanceOfType(e, typeof(Employee));
        }

        // Methods
        [TestMethod]
        public void Employee_PrintInfo_Should_Return_String_In_Correct_Format()
        {
            // Arrange
            var e = new Employee("firstName", "lastName", "phone", "email", RoleType.admin);

            // Act
            var printedInfo = e.PrintInfo();
            var expectedResult = string.Format(
                                    $"Full Name: {e.FirstName} {e.LastName}" + Environment.NewLine +
                                    $"Id: {e.Id}" + Environment.NewLine +
                                    $"Phone Number: {e.PhoneNumber}" + Environment.NewLine +
                                    $"Email: {e.Email}" + Environment.NewLine +
                                    $"Role: {e.Role}" + Environment.NewLine);

            // Assert
            Assert.AreEqual(expectedResult, printedInfo);
        }
    }
}
