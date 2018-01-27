using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using VetClinic.Commands.Implementations;
using VetClinic.Common.ConsoleServices.Contracts;
using VetClinic.Data.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;

namespace VetClinic.Test.VetClinic.Commands
{
    [TestClass]
    public class UserCommandTests
    {
        [TestMethod]
        public void Constructor_Should_Return_New_Instance_Of_UserCommand()
        {
            // Arrange & Act
            UserCommand userCommand = GetUserCommand();

            // Assert
            Assert.IsNotNull(userCommand);
            Assert.IsInstanceOfType(userCommand, typeof(UserCommand));
        }

        [TestMethod]
        public void CreateUser_Should_Call_UserRepository_CreateUserMethod_Once()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var userRepoMock = new Mock<IUserRepository>();
            var petRepoMock = new Mock<IPetRepository>();
            var writerMock = new Mock<IWriter>();

            var userCommand = new UserCommand(personFactoryMock.Object, userRepoMock.Object, petRepoMock.Object, writerMock.Object);

            var argsList = new List<string>()
            {
                "createuser",
                "firstname",
                "lastname",
                "phone",
                "email",
            };

            // Act
            userCommand.CreateUser(argsList);

            // Assert
            userRepoMock.Verify(x => x.CreateUser(It.IsAny<IUser>()), Times.Once);
        }

        [TestMethod]
        public void CreateUser_Should_Call_PersonFactory_CreateUserMethod_Once()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var userRepoMock = new Mock<IUserRepository>();
            var petRepoMock = new Mock<IPetRepository>();
            var writerMock = new Mock<IWriter>();

            var userCommand = new UserCommand(personFactoryMock.Object, userRepoMock.Object, petRepoMock.Object, writerMock.Object);

            var argsList = new List<string>()
            {
                "createuser",
                "firstname",
                "lastname",
                "phone",
                "email"
            };

            // Act
            userCommand.CreateUser(argsList);

            // Assert
            personFactoryMock.Verify(x => x.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);

        }

        [TestMethod]
        public void DeleteUser_Should_Call_UserRepository_DeleteUser_Once()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var userRepoMock = new Mock<IUserRepository>();
            var petRepoMock = new Mock<IPetRepository>();
            var writerMock = new Mock<IWriter>();

            var userCommand = new UserCommand(personFactoryMock.Object, userRepoMock.Object, petRepoMock.Object, writerMock.Object);

            var userCommandMock = new Mock<UserCommand>(personFactoryMock.Object, userRepoMock.Object, petRepoMock.Object, writerMock.Object);

            var argsList = new List<string>()
            {
                "deleteuser",
                "id"
            };

            userCommandMock.Object.DeleteUser(argsList); // TODO user cannot be found

            // Assert
            userRepoMock.Verify(x => x.DeleteUser(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void CreatePet_Should_Call_UserRepository_AddPet_Once()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var userRepoMock = new Mock<IUserRepository>();
            var petRepoMock = new Mock<IPetRepository>();
            var writerMock = new Mock<IWriter>();

            var userCommand = new UserCommand(personFactoryMock.Object, userRepoMock.Object, petRepoMock.Object, writerMock.Object);

            var argsList = new List<string>()
            {
                "createpet",
                "phone",
                "animalType",
                "animalName"
            };

            // Act
            userCommand.CreatePet(argsList); // TODO user cannot be found
            var user = new Mock<IUser>();

            // Assert
            user.Verify(x => x.AddPet(It.IsAny<IPet>()), Times.Once);

        }

        [TestMethod]
        public void DeletePet_Should_Call_UserRepository_DeletePet_Once()
        {

            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var userRepoMock = new Mock<IUserRepository>();
            var petRepoMock = new Mock<IPetRepository>();
            var writerMock = new Mock<IWriter>();

            var userCommand = new UserCommand(personFactoryMock.Object, userRepoMock.Object, petRepoMock.Object, writerMock.Object);

            var argsList = new List<string>()
            {
                "deletepet",
                "phone",
                "animalType",
                "animalName"
            };

            // Act
            userCommand.DeletePet(argsList); // TODO user cannot be found
            var user = new Mock<IUser>();

            // Assert
            user.Verify(x => x.RemovePet(It.IsAny<IPet>()), Times.Once);

        }

        private static UserCommand GetUserCommand()
        {
            var personFactoryMock = new Mock<IPersonFactory>();
            var userRepoMock = new Mock<IUserRepository>();
            var petRepoMock = new Mock<IPetRepository>();
            var writerMock = new Mock<IWriter>();

            return new UserCommand(personFactoryMock.Object, userRepoMock.Object, petRepoMock.Object, writerMock.Object);
        }
    }
}
