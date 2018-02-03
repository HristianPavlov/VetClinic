using System;
using VetClinic.Data.Enums;
using VetClinic.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VetClinic.Data.Contracts;
using Moq;
using System.Text;

namespace VetClinic.Test.VetClinic.Data.Models
{
    [TestClass]
    public class HamsterTests
    {
        // Constructor
        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Name_Is_Null()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Hamster(null, AnimalGenderType.male, 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Name_Is_Empty()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Hamster("", AnimalGenderType.male, 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Name_Is_Less_Than_2_Symbols_Long()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Hamster("a", AnimalGenderType.male, 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Name_Is_More_Than_15_Symbols_Long()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Hamster("aaaaaaaaaaaaaaaa", AnimalGenderType.male, 1));
        }

        [TestMethod]
        public void Constructor_Should_Create_New_Instance_Of_Class_Hamster()
        {
            // Arrange & Act
            var hamster = new Hamster("name", AnimalGenderType.male, 1);

            // Assert
            Assert.IsNotNull(hamster);
            Assert.IsInstanceOfType(hamster,typeof(Hamster));           
        }

        [TestMethod]
        public void Constructor_Should_Set_AnimalType_To_Hamster()
        {
            // Arrange & Act
            var hamster = new Hamster("name", AnimalGenderType.male, 1);
            var actualType = hamster.Type;
            var expectedType = AnimalType.hamster;

            // Assert
            Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod]
        public void Constructor_Should_Set_Correct_AnimalGenderType()
        {
            // Arrange & Act
            var hamster = new Hamster("name", AnimalGenderType.male, 1);
            var actualType = hamster.Gender;
            var expectedType = AnimalGenderType.male;

            // Assert
            Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Age_Is_Negative()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Hamster("name", AnimalGenderType.male, -1));
        }

        [TestMethod]
        public void Constructor_Should_Initialize_ListOfServices()
        {
            // Arrange & Act
            var hamster = new Hamster("name", AnimalGenderType.male, 1);

            // Assert
            Assert.IsNotNull(hamster.Services);
            Assert.IsInstanceOfType(hamster.Services, typeof(List<IService>));
        }

        // Methods
        [TestMethod]
        public void AddService_Should_Throw_ArgumentNullException_When_Service_Is_Null()
        {
            // Arrange
            var hamster = new Hamster("name", AnimalGenderType.male, 1);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => hamster.AddServices(null));
        }

        [TestMethod]
        public void AddService_Should_Add_Service_To_ListOfServices()
        {
            // Arrange
            var service = new Mock<IService>().Object;
            var hamster = new Hamster("name", AnimalGenderType.male, 1);

            // Act
            hamster.AddServices(service);

            // Assert
            Assert.IsTrue(hamster.Services.Contains(service));
        }

        [TestMethod]
        public void ListAnimalServices_Should__Return_Correct_Value_When_No_Services_Performed()
        {
            // Arrange
            var hamster = new Hamster("name", AnimalGenderType.male, 1);
            string expected = "No services performed yet";

            // Act
            string actual = hamster.ListAnimalServices();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListAnimalServices_Should_Return_Correct_Value()
        {
            // Arrange
            var service = new Mock<IService>();
            service.Setup(x => x.Name).Returns("ServiceName");
            var hamster = new Hamster("name", AnimalGenderType.male, 1);
            hamster.AddServices(service.Object);

            var sb = new StringBuilder();
            sb.AppendLine("All services: ");
            sb.AppendLine($"Service: ServiceName");
            string expected = sb.ToString();

            // Act
            string actual = hamster.ListAnimalServices();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintInfo_Should_Return_Correct_Value()
        {
            // Arrange
            var hamster = new Hamster("name", AnimalGenderType.male, 1);

            var sb = new StringBuilder();
            sb.AppendLine($"Pet Type: hamster");
            sb.AppendLine($"Name: name");
            sb.AppendLine($"Id: {hamster.Id}");
            sb.AppendLine($"Gender: male");
            sb.AppendLine("No services performed yet");
            string expected = sb.ToString();

            // Act
            string actual = hamster.PrintInfo();

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
