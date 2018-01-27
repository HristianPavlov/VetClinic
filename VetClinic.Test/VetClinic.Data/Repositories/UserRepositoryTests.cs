using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using VetClinic.Data.Contracts;
using VetClinic.Data.Repositories.Implementations;

namespace VetClinic.Test.VetClinic.Data.Repositories
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        public void Constructor_Should_Return_New_Instance()
        {
            // Arrange & Act
            var userRepository = new UserRepository();

            // Assert
            Assert.IsInstanceOfType(userRepository, typeof(UserRepository));
        }


        [TestMethod]
        public void Costructor_Should_Initialize_UserList()
        {
            // Arrange & Act
            var userRepository = new UserRepository();

            // Assert
            Assert.IsNotNull(userRepository.users);
        }

        [TestMethod]
        public void CreateUser_Should_Add_New_User_To_UserList()
        {
            // Arrange
            var userRepository = new UserRepository();
            var user = new Mock<IUser>();

            // Act
            userRepository.users.Add(user.Object);
            var expectedUser = userRepository.users.SingleOrDefault();

            //Assert
            Assert.IsNotNull(expectedUser);
            Assert.IsInstanceOfType(expectedUser, typeof(IUser));
            Assert.IsTrue(userRepository.users.Count == 1);
        }

        [TestMethod]
        public void DeleteUser_Should_Remove_New_User_To_UserList()
        {
            // Arrange
            var userRepository = new UserRepository();
            var user = new Mock<IUser>();

            // Act
            userRepository.users.Add(user.Object);
            userRepository.users.Remove(user.Object);
            var expectedUser = userRepository.users.SingleOrDefault();

            // Assert
            Assert.IsTrue(userRepository.users.Count == 0);
            Assert.IsNull(expectedUser);

        }
    }
}
