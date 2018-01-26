using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VetClinic.Data.Enums;
using VetClinic.Data.Models;

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
            Assert.IsNotNull(dog);
            Assert.IsInstanceOfType(dog, typeof(Dog));
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
    }
}
