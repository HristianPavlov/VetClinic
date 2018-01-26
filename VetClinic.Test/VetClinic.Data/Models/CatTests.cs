using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VetClinic.Data.Enums;
using VetClinic.Data.Models;

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
    }
}
