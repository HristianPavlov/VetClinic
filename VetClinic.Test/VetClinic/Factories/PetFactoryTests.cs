using Microsoft.VisualStudio.TestTools.UnitTesting;
using VetClinic.Data.Contracts;
using VetClinic.Data.Enums;
using VetClinic.Factories.Implemetations;

namespace VetClinic.Test.VetClinic.Factories
{
    [TestClass]
    public class PetFactoryTests
    {
        [TestMethod]
        public void CreateDog_Should_Return_Instance_Of_Type_IPet()
        {
            // Arrange & Act
            var dog = new PetFactory().CreateDog("name",AnimalGenderType.female, "breed", 1);

            // Assert
            Assert.IsInstanceOfType(dog, typeof(IPet));
        }
    }
}
