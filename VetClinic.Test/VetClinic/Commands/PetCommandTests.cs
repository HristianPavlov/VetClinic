using Moq;
using System.Linq;
using System.Collections.Generic;
using VetClinic.Factories.Contracts;
using VetClinic.Providers.Contracts;
using VetClinic.Commands.Implementations;
using VetClinic.Data.Repositories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VetClinic.Data.Contracts;
using System;
using VetClinic.Data.Enums;

namespace VetClinic.Test.VetClinic.Commands
{
    [TestClass]
    public class PetCommandTests
    {
        [TestMethod]
        public void Constructor_Should_Return_New_Instance_Of_PetCommand()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>().Object;
            var petRepository = new Mock<IPetRepository>().Object;
            var writer = new Mock<IWriter>().Object;

            // Act
            var petCommand = new PetCommand(petFactory, petRepository, writer);

            // Assert
            Assert.IsInstanceOfType(petCommand, typeof(PetCommand));
        }

        [TestMethod]
        public void DeletePet_Should_Call_PetRepository_With_Correct_Pet()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var petRepository = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var expectedPet = new Mock<IPet>().Object;
            petRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(expectedPet);
            var petCommand = new PetCommand(petFactory.Object, petRepository.Object, writer.Object);
            IPet actualPet = null;

            petRepository.Setup(x => x.DeletePet(It.IsAny<string>(), It.IsAny<IPet>()))
                .Callback<string, IPet>((user, pet) => actualPet = pet);

            var parameters = new List<string>() { "", "", "" };

            // Act
            petCommand.DeletePet(parameters);

            // Assert
            Assert.IsNotNull(actualPet);
            Assert.AreEqual(expectedPet, actualPet);
        }

        [TestMethod]
        public void DeletePet_Should_Throw_ArgumentNullException_When_Pet_Not_Found()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var petRepository = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            petRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns((IPet)null);
            var petCommand = new PetCommand(petFactory.Object, petRepository.Object, writer.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => petCommand.DeletePet(new List<string>() { "", "", "" }));
        }

        [TestMethod]
        public void DeletePet_Should_Call_PetRepo_GetById_Method()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var petRepository = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            var expectedPet = new Mock<IPet>().Object;
            petRepository.Setup(x => x.GetById("1234")).Returns(expectedPet);

            var petCommand = new PetCommand(petFactory.Object, petRepository.Object, writer.Object);

            //Act
            petCommand.DeletePet(new List<string>() { "", "", "1234" });

            // Assert
            petRepository.Verify(x => x.GetById("1234"), Times.Once);
        }

        [TestMethod]
        public void CreatePet_Should_Call_PetFactory_CreateCat_Method()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var petRepository = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var mockPet = new Mock<IPet>().Object;

            petFactory.Setup
                (x => x.CreateCat(It.IsAny<string>(), It.IsAny<AnimalGenderType>(), It.IsAny<int>()))
                .Returns(mockPet);

            var petCommand = new PetCommand(petFactory.Object, petRepository.Object, writer.Object);

            //Act
            petCommand.CreatePet(new List<string>() { "", "", "cat", "name", "female", "2"});

            // Assert
            petFactory.Verify(x => x.CreateCat("name", AnimalGenderType.female, 2), Times.Once);
        }

        [TestMethod]
        public void CreatePet_Should_Call_PetRepository_CreateCat_Method()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var petRepository = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var mockPet = new Mock<IPet>().Object;

            petFactory.Setup
                (x => x.CreateCat(It.IsAny<string>(), It.IsAny<AnimalGenderType>(), It.IsAny<int>()))
                .Returns(mockPet);

            var petCommand = new PetCommand(petFactory.Object, petRepository.Object, writer.Object);

            //Act
            petCommand.CreatePet(new List<string>() { "", "1234", "cat", "name", "female", "2" });

            // Assert
            petRepository.Verify(x => x.CreatePet("1234", mockPet), Times.Once);
        }

        [TestMethod]
        public void CreatePet_Should_Call_PetFactory_CreateDog_Method()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var petRepository = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var mockPet = new Mock<IPet>().Object;

            petFactory.Setup
                (x => x.CreateDog(It.IsAny<string>(), It.IsAny<AnimalGenderType>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(mockPet);

            var petCommand = new PetCommand(petFactory.Object, petRepository.Object, writer.Object);

            //Act
            petCommand.CreatePet(new List<string>() { "", "", "dog", "name", "female", "2", "breed"});

            // Assert
            petFactory.Verify(x => x.CreateDog("name", AnimalGenderType.female, "breed", 2), Times.Once);
        }

        [TestMethod]
        public void CreatePet_Should_Call_PetRepository_CreateDog_Method()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var petRepository = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var mockPet = new Mock<IPet>().Object;

            petFactory.Setup
                (x => x.CreateDog(It.IsAny<string>(), It.IsAny<AnimalGenderType>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(mockPet);

            var petCommand = new PetCommand(petFactory.Object, petRepository.Object, writer.Object);

            //Act
            petCommand.CreatePet(new List<string>() { "", "1234", "dog", "name", "female", "2", "breed" });

            // Assert
            petRepository.Verify(x => x.CreatePet("1234", mockPet), Times.Once);
        }

        [TestMethod]
        public void CreatePet_Should_Call_PetFactory_CreateHamster_Method()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var petRepository = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var mockPet = new Mock<IPet>().Object;

            petFactory.Setup
                (x => x.CreateHamster(It.IsAny<string>(), It.IsAny<AnimalGenderType>(), It.IsAny<int>()))
                .Returns(mockPet);

            var petCommand = new PetCommand(petFactory.Object, petRepository.Object, writer.Object);

            //Act
            petCommand.CreatePet(new List<string>() { "", "", "hamster", "name", "female", "2" });

            // Assert
            petFactory.Verify(x => x.CreateHamster("name", AnimalGenderType.female, 2), Times.Once);
        }

        [TestMethod]
        public void CreatePet_Should_Call_PetRepository_CreateHamster_Method()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var petRepository = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var mockPet = new Mock<IPet>().Object;

            petFactory.Setup
                (x => x.CreateHamster(It.IsAny<string>(), It.IsAny<AnimalGenderType>(), It.IsAny<int>()))
                .Returns(mockPet);

            var petCommand = new PetCommand(petFactory.Object, petRepository.Object, writer.Object);

            //Act
            petCommand.CreatePet(new List<string>() { "", "1234", "hamster", "name", "female", "2" });

            // Assert
            petRepository.Verify(x => x.CreatePet("1234", mockPet), Times.Once);
        }
    }
}
