using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VetClinic.Commands.Implementations;
using VetClinic.Common.ConsoleServices.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;

namespace VetClinic.Test.VetClinic.Commands
{
    [TestClass]
    public class UserCommandTests
    {
        [TestMethod]
        public void Constructor_Should_Return_New_Instance()
        {
            // Arrange & Act
            UserCommand userCommand = GetUserCommand();

            // Assert
            Assert.IsInstanceOfType(userCommand, typeof(UserCommand));
        }

        [TestMethod]
        public void Contructor_Should_Return_New_Instance_Not_Null()
        {
            // Arrange & Act
            UserCommand userCommand = GetUserCommand();

            // Assert
            Assert.IsNotNull(userCommand);
        }

        private static UserCommand GetUserCommand()
        {
            // Arrange
            var personFactoryMock = new Mock<IPersonFactory>();
            var usersMock = new Mock<IUserRepository>();
            var petsMock = new Mock<IPetRepository>();
            var writerMock = new Mock<IWriter>();

            // Act
            return new UserCommand(personFactoryMock.Object, usersMock.Object, petsMock.Object, writerMock.Object);
        }
    }
}
