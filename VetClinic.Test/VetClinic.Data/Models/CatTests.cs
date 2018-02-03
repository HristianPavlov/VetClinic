using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VetClinic.Data.Enums;
using VetClinic.Data.Models;
using System.Collections.Generic;
using VetClinic.Data.Contracts;
using Moq;
using System.Text;

namespace VetClinic.Test.VetClinic.Data.Models
{
    [TestClass]
    public class CatTests
    {
        // Constructor
        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Name_Is_Null()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Cat(null, AnimalGenderType.male, 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Name_Is_Empty()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Cat(string.Empty, AnimalGenderType.male, 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Name_Is_Less_Then_2_Symbols_Long()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Cat("a", AnimalGenderType.male, 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Name_Is_More_Then_15_Symbols_Long()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Cat("aaaaaaaaaaaaaaaa", AnimalGenderType.male, 1));
        }
      
        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Age_Is_Negative()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Cat("name", AnimalGenderType.male, -1));
        }

        [TestMethod]
        public void Constructor_Should_Create_New_Intsnace_Of_Class_Cat()
        {
            // Arrange & Act
            var cat = new Cat("name", AnimalGenderType.male, 1);

            // Assert
            Assert.IsNotNull(cat);
            Assert.IsInstanceOfType(cat, typeof(Cat));
        }

        [TestMethod]
        public void Constructor_Should_Set_AnimalType_To_Cat()
        {
            // Arrange & Act
            var cat = new Cat("name", AnimalGenderType.male, 1);
            var actualType = cat.Type;
            var expectedType = AnimalType.cat;

            // Assert
            Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod]
        public void Constructor_Should_Set_Correct_AnimalGenderType()
        {
            // Arrange & Act
            var cat = new Cat("name", AnimalGenderType.male, 1);
            var actualType = cat.Gender;
            var expectedType = AnimalGenderType.male;

            // Assert
            Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod]
        public void Constructor_Should_Initialize_ListOfServices()
        {
            // Arrange & Act
            var cat = new Cat("name", AnimalGenderType.male, 1);

            // Assert
            Assert.IsNotNull(cat.Services);
            Assert.IsInstanceOfType(cat.Services, typeof(List<IService>));
        }

        // Methods
        [TestMethod]
        public void Cat_PrintInfo_Should_Return_String_In_Correct_Format()
        {
            // Arrange
            var cat = new Cat("name", AnimalGenderType.female, 1);

            // Act
            var printedInfo = cat.PrintInfo();
            var expectedResult = string.Format(
                                    $"Pet Type: {cat.Type}" + Environment.NewLine +
                                    $"Name: {cat.Name}" + Environment.NewLine +
                                    $"Id: {cat.Id}" + Environment.NewLine +
                                    $"Gender: {cat.Gender}" + Environment.NewLine +
                                    "No services performed yet" + Environment.NewLine);

            // Assert
            Assert.AreEqual(expectedResult, printedInfo);
        }

        [TestMethod]
        public void AddService_Should_Throw_ArgumentNullException_When_Service_Is_Null()
        {
            // Arrange
            var cat = new Cat("name", AnimalGenderType.male, 1);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => cat.AddServices(null));
        }

        [TestMethod]
        public void AddService_Should_Add_Service_To_ListOfServices()
        {
            // Arrange
            var service = new Mock<IService>().Object;
            var cat = new Cat("name", AnimalGenderType.male, 1);

            // Act
            cat.AddServices(service);

            // Assert
            Assert.IsTrue(cat.Services.Contains(service));
        }

        [TestMethod]
        public void ListAnimalServices_Should__Return_Correct_Value_When_No_Services_Performed()
        {
            // Arrange
            var cat = new Cat("name", AnimalGenderType.male, 1);
            string expected = "No services performed yet";

            // Act
            string actual = cat.ListAnimalServices();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListAnimalServices_Should_Return_Correct_Value()
        {
            // Arrange
            var service = new Mock<IService>();
            service.Setup(x => x.Name).Returns("ServiceName");
            var cat = new Cat("name", AnimalGenderType.male, 1);
            cat.AddServices(service.Object);

            var sb = new StringBuilder();
            sb.AppendLine("All services: ");
            sb.AppendLine($"Service: ServiceName");
            string expected = sb.ToString();

            // Act
            string actual = cat.ListAnimalServices();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
