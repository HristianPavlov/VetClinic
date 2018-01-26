using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VetClinic.Data.Models;

namespace VetClinic.Test.VetClinic.Data.Models
{
    [TestClass]
    public class UserTests
    {
        // Constructor
        public void Constructor_Should_Throw_ArgumentNullException_When_FirstName_Is_Null()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new User(null, "lastName", "phone", "email"));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_FirstName_Is_Empty()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new User(string.Empty, "lastName", "phone", "email"));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_LastName_Is_Null()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new User("firstName", null, "phone", "email"));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_LastName_Is_Empty()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new User("firstName", string.Empty, "phone", "email"));
        }

        [TestMethod]
        public void Constructor_Should_Create_New_Instance_Of_Class_Employee()
        {
            // Arrange & Act
            var e = new User("firstName", "lastName", "phone", "email");

            // Assert
            Assert.IsNotNull(e);
            Assert.IsInstanceOfType(e, typeof(User));
        }
    }
}
