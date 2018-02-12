using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using VetClinic.Commands.Contracts;
using VetClinic.Core.Commands.Implementations.PetCommands;
using VetClinic.Data.Contracts;
using VetClinic.Data.Enums;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Test.VetClinic.Commands.Implementations
{
    [TestClass]
    public class PetCommandsTests
    {
        [TestMethod]
        public void CreatePetCommand_Execute_Should_Call_UserRepo()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            var pet = new Mock<IPet>();
            var user = new Mock<IUser>();
            user.SetupGet(m => m.PhoneNumber).Returns("123456");

            petFactory.Setup(m => m.CreateCat("Kitty", AnimalGenderType.female, 2)).Returns(pet.Object);
            users.SetupGet(m => m.Users).Returns(new List<IUser>() { user.Object });

            var createPetCommand = new CreatePetCommand
                (petFactory.Object, users.Object, pets.Object, writer.Object);

            createPetCommand.Parameters = new List<string> { "createpet", "123456", "cat", "Kitty", "female", "2" };

            // Act
            createPetCommand.Execute();

            // Assert
            users.Verify(m => m.Users, Times.Once);
        }

        [TestMethod]
        public void CreatePetCommand_Execute_Should_Call_PetsMethod_CreatePetMethod()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            var pet = new Mock<IPet>();
            var user = new Mock<IUser>();
            user.SetupGet(m => m.PhoneNumber).Returns("123456");

            petFactory.Setup(m => m.CreateCat("Kitty", AnimalGenderType.female, 2)).Returns(pet.Object);
            users.SetupGet(m => m.Users).Returns(new List<IUser>() { user.Object });

            var createPetCommand = new CreatePetCommand
                (petFactory.Object, users.Object, pets.Object, writer.Object);

            createPetCommand.Parameters = new List<string> { "createpet", "123456", "cat", "Kitty", "female", "2"};

            // Act
            createPetCommand.Execute();

            // Assert
            pets.Verify(m => m.CreatePet(It.IsAny<string>(), pet.Object), Times.Once);
        }

        [TestMethod]
        public void CreatePetCommand_Execute_Should_Call_UserMethod_AddPet()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            var pet = new Mock<IPet>();
            var user = new Mock<IUser>();
            var dataBase = new List<IPet>();

            user.SetupGet(m => m.PhoneNumber).Returns("123456");
            user.SetupGet(m => m.Pets).Returns(new List<IPet>());
            petFactory.Setup(m => m.CreateCat("Kitty", AnimalGenderType.female, 2)).Returns(pet.Object);
            users.SetupGet(m => m.Users).Returns(new List<IUser>() { user.Object });
            pets.SetupGet(m => m.Pets).Returns(new List<IPet>());

            var createPetCommand = new CreatePetCommand
                (petFactory.Object, users.Object, pets.Object, writer.Object);

            createPetCommand.Parameters = new List<string> { "createpet", "123456", "cat", "Kitty", "female", "2" };

            // Act
            createPetCommand.Execute();

            // Assert
            user.Verify(m => m.AddPet(pet.Object), Times.Once);
        }

        [TestMethod]
        public void CreatePetCommand_Execute_Should_Throw_ArgumentNullException_When_User_Not_Found()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            var pet = new Mock<IPet>();
            var user = new Mock<IUser>();
            user.SetupGet(m => m.PhoneNumber).Returns("123456");

            users.SetupGet(m => m.Users).Returns(new List<IUser>());

            var createPetCommand = new CreatePetCommand
                (petFactory.Object, users.Object, pets.Object, writer.Object);

            createPetCommand.Parameters = new List<string> { "createpet", "123456", "cat", "Kitty", "female", "2" };

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => createPetCommand.Execute());
        }

        [TestMethod]
        public void CreatePetCommand_Constructor_Should_CreateInstance_Of_Type_ICommand()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            // Act
            var createPetCommand = new CreatePetCommand
                (petFactory.Object, users.Object, pets.Object, writer.Object);

            // Assert
            Assert.IsInstanceOfType(createPetCommand, typeof(ICommand));
        }

        [TestMethod]
        public void CreatePetCommand_Constructor_Should_Throw_ArgumentNullException_When_PetFactory_Is_Null()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            ICommand createPetCommand;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => createPetCommand = new CreatePetCommand
                (null, users.Object, pets.Object, writer.Object));
        }

        [TestMethod]
        public void CreatePetCommand_Constructor_Should_Throw_ArgumentNullException_When_Writer_Is_Null()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();

            ICommand createPetCommand;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => createPetCommand = new CreatePetCommand
                (petFactory.Object, users.Object, pets.Object, null));
        }

        [TestMethod]
        public void CreatePetCommand_Constructor_Should_Throw_ArgumentNullException_When_UserRepo_Is_Null()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            ICommand createPetCommand;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => createPetCommand = new CreatePetCommand
                (petFactory.Object, null, pets.Object, writer.Object));
        }

        [TestMethod]
        public void CreatePetCommand_Constructor_Should_Throw_ArgumentNullException_When_PetRepo_Is_Null()
        {
            // Arrange
            var petFactory = new Mock<IPetFactory>();
            var users = new Mock<IUserRepository>();
            var writer = new Mock<IWriter>();

            ICommand createPetCommand;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => createPetCommand = new CreatePetCommand
                (petFactory.Object, users.Object, null, writer.Object));
        }

        [TestMethod]
        public void DeletePetCommand_Constructor_Should_Throw_ArgumentNullException_When_PetRepo_Is_Null()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var writer = new Mock<IWriter>();

            ICommand deletePetCommand;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => deletePetCommand = new DeletePetCommand
                (null, users.Object, writer.Object));
        }

        [TestMethod]
        public void DeletePetCommand_Constructor_Should_Throw_ArgumentNullException_When_UserRepo_Is_Null()
        {
            // Arrange
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            ICommand deletePetCommand;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => deletePetCommand = new DeletePetCommand
                (pets.Object, null, writer.Object));
        }

        [TestMethod]
        public void DeletePetCommand_Constructor_Should_Throw_ArgumentNullException_When_Writer_Is_Null()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();

            ICommand deletePetCommand;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => deletePetCommand = new DeletePetCommand
                (pets.Object, users.Object, null));
        }

        public void DeletePetCommand_Execute_Should_Call_UserRepo()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var user = new Mock<IUser>();

            user.SetupGet(m => m.PhoneNumber).Returns("123456");
            users.SetupGet(m => m.Users).Returns(new List<IUser>() { user.Object });

            var deletePetCommand = new DeletePetCommand(pets.Object, users.Object, writer.Object);

            deletePetCommand.Parameters = new List<string> { "deletepet", "123456", "Kitty" };

            // Act
            deletePetCommand.Execute();

            // Assert
            users.Verify(m => m.Users, Times.Once);
        }

        [TestMethod]
        public void DeletePetCommand_Execute_Should_Call_PetsMethod_DeletePetMethod()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var pet = new Mock<IPet>();
            var user = new Mock<IUser>();

            pet.SetupGet(m => m.Name).Returns("Kitty");
            pets.SetupGet(m => m.Pets).Returns(new List<IPet>() { pet.Object });
            user.SetupGet(m => m.PhoneNumber).Returns("123456");
            user.SetupGet(m => m.Pets).Returns(new List<IPet>() { pet.Object });
            users.SetupGet(m => m.Users).Returns(new List<IUser>() { user.Object });

            var deletePetCommand = new DeletePetCommand(pets.Object, users.Object, writer.Object);

            deletePetCommand.Parameters = new List<string> { "deletepet", "123456", "Kitty" };

            // Act
            deletePetCommand.Execute();

            // Assert
            pets.Verify(m => m.DeletePet("123456", pet.Object), Times.Once);
        }

        [TestMethod]
        public void DeletePetCommand_Execute_Should_Call_UserMethod_RemovePet()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var pet = new Mock<IPet>();
            var user = new Mock<IUser>();
            var dataBase = new List<IPet>();

            pet.SetupGet(m => m.Name).Returns("Kitty");
            pets.SetupGet(m => m.Pets).Returns(new List<IPet>() { pet.Object});
            user.SetupGet(m => m.PhoneNumber).Returns("123456");
            user.SetupGet(m => m.Pets).Returns(new List<IPet>() { pet.Object });
            users.SetupGet(m => m.Users).Returns(new List<IUser>() { user.Object });

            var deletePetCommand = new DeletePetCommand(pets.Object, users.Object, writer.Object);

            deletePetCommand.Parameters = new List<string> { "deletepet", "123456", "Kitty" };

            // Act
            deletePetCommand.Execute();

            // Assert
            user.Verify(m => m.RemovePet(pet.Object), Times.Once);
        }

        [TestMethod]
        public void DeletePetCommand_Execute_Should_Throw_ArgumentNullException_When_User_Not_Found()
        {
            // Arrange
            var users = new Mock<IUserRepository>();
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var pet = new Mock<IPet>();
            var user = new Mock<IUser>();

            user.SetupGet(m => m.PhoneNumber).Returns("123456");
            users.SetupGet(m => m.Users).Returns(new List<IUser>());

            var deletePetCommand = new DeletePetCommand(pets.Object, users.Object, writer.Object);

            deletePetCommand.Parameters = new List<string> { "deletepet", "123456", "Kitty" };

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => deletePetCommand.Execute());
        }

        [TestMethod]
        public void ListPetsCommand_Constructor_Should_Throw_ArgumentNullException_When_Writer_Is_Null()
        {
            // Arrange
            var pets = new Mock<IPetRepository>();

            ICommand listPetsCommand;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => listPetsCommand = new ListPetsCommand
                (pets.Object, null));
        }

        [TestMethod]
        public void ListPetsCommand_Constructor_Should_Throw_ArgumentNullException_When_PetRepo_Is_Null()
        {
            // Arrange
            var writer = new Mock<IWriter>();

            ICommand listPetsCommand;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => listPetsCommand = new ListPetsCommand
                (null, writer.Object));
        }

        [TestMethod]
        public void ListPetsCommand_Constructor_Should_Create_Instance_OfType_ICommand()
        {
            // Arrange
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();

            ICommand listPetsCommand = new ListPetsCommand(pets.Object, writer.Object);

            // Act & Assert
            Assert.IsInstanceOfType(listPetsCommand, typeof(ICommand));
        }

        [TestMethod]
        public void ListPetsCommand_Execute_Should_Call_PetRepo_Pets()
        {
            // Arrange
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var pet = new Mock<IPet>();

            pets.SetupGet(m => m.Pets).Returns(new List<IPet>() { pet.Object });

            ICommand listPetsCommand = new ListPetsCommand(pets.Object, writer.Object);

            // Act 
            listPetsCommand.Execute();

            // Assert
            pets.Verify(m => m.Pets, Times.Once);
        }

        [TestMethod]
        public void ListPetsCommand_Execute_Should_Call_Pet_PrintInfoMethod()
        {
            // Arrange
            var pets = new Mock<IPetRepository>();
            var writer = new Mock<IWriter>();
            var pet = new Mock<IPet>();

            pets.SetupGet(m => m.Pets).Returns(new List<IPet>() { pet.Object });

            ICommand listPetsCommand = new ListPetsCommand(pets.Object, writer.Object);

            // Act 
            listPetsCommand.Execute();

            // Assert
            pet.Verify(m => m.PrintInfo(), Times.Once);
        }
    }
}
