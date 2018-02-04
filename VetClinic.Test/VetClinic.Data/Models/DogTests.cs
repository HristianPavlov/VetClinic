using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VetClinic.Data.Enums;
using VetClinic.Data.Models;
using VetClinic.Data.Contracts;
using System.Collections.Generic;
using Moq;
using System.Text;

namespace VetClinic.Test.VetClinic.Data.Models
{
    [TestClass]
    public class DogTests
    {
        // Constructor
        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Name_Is_Null()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Dog(null, AnimalGenderType.male, "breed", 1)); 
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Name_Is_Empty()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dog(string.Empty, AnimalGenderType.male, "breed", 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Name_Is_Less_Then_2_Symbols_Long()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dog("a", AnimalGenderType.male, "breed", 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Name_Is_More_Then_15_Symbols_Long()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dog("aaaaaaaaaaaaaaaa", AnimalGenderType.male, "breed", 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Breed_Is_Empty()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dog("name", AnimalGenderType.male, string.Empty ,1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Breed_Is_Less_Then_2_Symbols_Long()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dog("name", AnimalGenderType.male, "a", 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Breed_Is_More_Then_15_Symbols_Long()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dog("name", AnimalGenderType.male, "aaaaaaaaaaaaaaaa", 1));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentException_When_Age_Is_Negative()
        {
            // Arrage & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Dog("name", AnimalGenderType.male, "breed", -1));
        }

        [TestMethod]
        public void Constructor_Should_Create_New_Intsnace_Of_Class_Dog()
        {
            // Arrange & Act
            var dog = new Dog("name", AnimalGenderType.male, "breed", 1);

            // Assert
            Assert.IsInstanceOfType(dog, typeof(Dog));
        }

        [TestMethod]
        public void Constructor_Should_Set_AnimalType_To_Cat()
        {
            // Arrange & Act
            var dog = new Dog("name", AnimalGenderType.male, "breed", 1);
            var actualType = dog.Type;
            var expectedType = AnimalType.dog;

            // Assert
            Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod]
        public void Constructor_Should_Set_Correct_AnimalGenderType()
        {
            // Arrange & Act
            var dog = new Dog("name", AnimalGenderType.male, "breed", 1);
            var actualType = dog.Gender;
            var expectedType = AnimalGenderType.male;

            // Assert
            Assert.AreEqual(expectedType, actualType);
        }

        [TestMethod]
        public void Constructor_Should_Initialize_ListOfServices()
        {
            // Arrange & Act
            var dog = new Dog("name", AnimalGenderType.male, "breed", 1);

            // Assert
            Assert.IsNotNull(dog.Services);
            Assert.IsInstanceOfType(dog.Services, typeof(List<IService>));
        }

        // Methods
        [TestMethod]
        public void Dog_PrintInfo_Should_Return_String_In_Correct_Format()
        {
            // Arrange
            var dog = new Dog("name", AnimalGenderType.female, "breed", 1);

            // Act
            var printedInfo = dog.PrintInfo();
            var expectedResult = string.Format(
                                    $"Pet Type: {dog.Type}" + Environment.NewLine +
                                    $"Name: {dog.Name}" + Environment.NewLine +
                                    $"Id: {dog.Id}" + Environment.NewLine +
                                    $"Gender: {dog.Gender}" + Environment.NewLine +
                                    "No services performed yet" + Environment.NewLine +
                                    $"Breed: {dog.Breed}" + Environment.NewLine);

            // Assert
            Assert.AreEqual(expectedResult, printedInfo);
        }

        [TestMethod]
        public void AddService_Should_Throw_ArgumentNullException_When_Service_Is_Null()
        {
            // Arrange
            var dog = new Dog("name", AnimalGenderType.female, "breed", 1);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dog.AddServices(null));
        }

        [TestMethod]
        public void AddService_Should_Add_Service_To_ListOfServices()
        {
            // Arrange
            var service = new Mock<IService>().Object;
            var dog = new Dog("name", AnimalGenderType.female, "breed", 1);

            // Act
            dog.AddServices(service);

            // Assert
            Assert.IsTrue(dog.Services.Contains(service));
        }

        [TestMethod]
        public void ListAnimalServices_Should__Return_Correct_Value_When_No_Services_Performed()
        {
            // Arrange
            var dog = new Dog("name", AnimalGenderType.female, "breed", 1);
            string expected = "No services performed yet";

            // Act
            string actual = dog.ListAnimalServices();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListAnimalServices_Should_Return_Correct_Value()
        {
            // Arrange
            var service = new Mock<IService>();
            service.Setup(x => x.Name).Returns("ServiceName");
            var dog = new Dog("name", AnimalGenderType.female, "breed", 1);
            dog.AddServices(service.Object);

            var sb = new StringBuilder();
            sb.AppendLine("All services: ");
            sb.AppendLine($"Service: ServiceName");
            string expected = sb.ToString();

            // Act
            string actual = dog.ListAnimalServices();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
