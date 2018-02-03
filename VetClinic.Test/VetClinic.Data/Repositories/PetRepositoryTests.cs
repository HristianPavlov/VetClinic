using Moq;
using System;
using System.Linq;
using VetClinic.Data.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Data.Repositories.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VetClinic.Test.VetClinic.Data.Repositories
{
    [TestClass]
    public class PetRepositoryTests
    {
        [TestMethod]
        public void Constructor_Should_Set_Users_Correctly()
        {
            // Arrange & Act
            var users = new Mock<IUserRepository>().Object;
            var petRepository = new PetRepository(users);

            // Assert
            Assert.AreEqual(users, petRepository.Users);
        }

        [TestMethod]
        public void Constructor_Should_Return_New_Instance()
        {
            // Arrange & Act
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);

            // Assert
            Assert.IsInstanceOfType(petRepository, typeof(PetRepository));
        }

        [TestMethod]
        public void Costructor_Should_Initialize_PetList()
        {
            // Arrange & Act
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);

            // Assert
            Assert.IsNotNull(petRepository.Pets);
        }

        [TestMethod]
        public void GetById_Should_Return_Correct_Pet()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);
            var pet = new Mock<IPet>();
            pet.Setup(x => x.Id).Returns("some id");
            var expected = pet.Object;
            petRepository.CreatePet("", expected);

            // Act
            var actual = petRepository.GetById("some id");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatePet_Should_Add_New_Pet_To_PetList()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);
            var pet = new Mock<IPet>();

            // Act
            petRepository.CreatePet("12345",pet.Object);
            var expectedPet = petRepository.Pets.SingleOrDefault();

            //Assert
            Assert.IsNotNull(expectedPet);
            Assert.IsInstanceOfType(expectedPet, typeof(IPet));
            Assert.IsTrue(petRepository.Pets.Count == 1);
        }

        [TestMethod]
        public void CreatePet_Should_Add_Pet_To_PetList_Correctly()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);
            var pet = new Mock<IPet>();

            // Act
            petRepository.CreatePet("", pet.Object);

            // Assert
            Assert.IsTrue(petRepository.Pets.Count == 1);
            Assert.IsTrue(petRepository.Pets.Contains(pet.Object));
        }

        [TestMethod]
        public void CreatePet_Should_Throw_ArgumentException_When_Pet_Exists()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);
            var pet = new Mock<IPet>();
            petRepository.CreatePet("",pet.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => petRepository.CreatePet("", pet.Object));
            
        }

        [TestMethod]
        public void CreatePet_Should_Throw_ArgumentNullException_When_Pet_Is_Null()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => petRepository.CreatePet("", null));
        }

        [TestMethod]
        public void DeletePet_Should_Throw_ArgumentNullException_When_Pet_Is_Null()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => petRepository.DeletePet("", null));
        }

        [TestMethod]
        public void DeletePet_Should_Remove_Pet_From_PetList()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);
            var pet = new Mock<IPet>();

            // Act
            petRepository.CreatePet("", pet.Object);
            petRepository.DeletePet("", pet.Object);

            // Assert
            Assert.IsTrue(!petRepository.Pets.Contains(pet.Object));
        }

        [TestMethod]
        public void DeletePet_Should_Throw_ArgumentException_When_Pet_Does_Not_Exist()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var petRepository = new PetRepository(users.Object);
            var pet = new Mock<IPet>();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => petRepository.DeletePet("", pet.Object));
        }
    }
}