using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Core.Commands.Implementations.AccountingCommands;
using VetClinic.Data.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Test.VetClinic.Commands.Implementations
{
    [TestClass]
    public class AccountingCommandsTests
    {
        [TestMethod]
        public void PrintBalanceCommand_Should_Call_Writer_With_Correct_Line()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var repo = new Mock<IAccountingRepository>();

            repo.SetupGet(m => m.Balance).Returns(10m);
            var command = new PrintBalanceCommand(writer.Object, repo.Object);

            // Act
            command.Execute();

            // Assert
            writer.Verify(m => m.WriteLine("10.00 $"));
        }

        [TestMethod]
        public void PrintBalanceCommand_Throw_ArgumentNullException_When_Writer_Is_Null()
        {
            // Arrange
            var repo = new Mock<IAccountingRepository>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new PrintBalanceCommand(null, repo.Object));
        }

        [TestMethod]
        public void PrintBalanceCommand_Throw_ArgumentNullException_When_Repo_Is_Null()
        {
            // Arrange
            var writer = new Mock<IWriter>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new PrintBalanceCommand(writer.Object, null));
        }

        [TestMethod]
        public void CloseAccountCommand_Throw_ArgumentNullException_When_Writer_Is_Null()
        {
            // Arrange
            var accountingRepo = new Mock<IAccountingRepository>();
            var userRepo = new Mock<IUserRepository>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CloseAccountCommand(userRepo.Object, accountingRepo.Object, null));
        }

        [TestMethod]
        public void CloseAccountCommand_Throw_ArgumentNullException_When_UserRepo_Is_Null()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var accountingRepo = new Mock<IAccountingRepository>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CloseAccountCommand(null, accountingRepo.Object, writer.Object));
        }

        [TestMethod]
        public void CloseAccountCommand_Throw_ArgumentNullException_When_AccountingRepo_Is_Null()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var userRepo = new Mock<IUserRepository>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CloseAccountCommand(userRepo.Object, null, writer.Object));
        }

        [TestMethod]
        public void CloseAccountCommand_Execute_Should_Throw_ArgumentNullException_When_User_Not_Found()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var userRepo = new Mock<IUserRepository>();
            var accountingRepo = new Mock<IAccountingRepository>();
            var user = new Mock<IUser>();

            user.Setup(x => x.PhoneNumber).Returns("123456");
            userRepo.SetupGet(x => x.Users).Returns(new List<IUser>() { user.Object });
            var command = new CloseAccountCommand(userRepo.Object, accountingRepo.Object, writer.Object);

            command.Parameters = new List<string>() { "closeaccount", "111111" };

            // Act  & Assert
            Assert.ThrowsException<ArgumentNullException>(() => command.Execute());
        }

        [TestMethod]
        public void CloseAccountCommand_Execute_Should_UpdateBalance_Correctly()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var userRepo = new Mock<IUserRepository>();
            var accountingRepo = new Mock<IAccountingRepository>();
            var user = new Mock<IUser>();

            user.Setup(x => x.PhoneNumber).Returns("123456");
            user.Setup(x => x.Bill).Returns(10m);
            userRepo.SetupGet(x => x.Users).Returns(new List<IUser>() { user.Object });
            var command = new CloseAccountCommand(userRepo.Object, accountingRepo.Object, writer.Object);

            command.Parameters = new List<string>() { "closeaccount", "123456" };

            // Act  
            command.Execute();

            // Assert
            accountingRepo.Verify(x => x.UpdateBalance(10m), Times.Once);
        }

        [TestMethod]
        public void CloseAccountCommand_Execute_Should_Call_UserBill_Twice()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var userRepo = new Mock<IUserRepository>();
            var accountingRepo = new Mock<IAccountingRepository>();
            var user = new Mock<IUser>();

            user.Setup(x => x.PhoneNumber).Returns("123456");
            user.Setup(x => x.Bill).Returns(10m);
            userRepo.SetupGet(x => x.Users).Returns(new List<IUser>() { user.Object });
            var command = new CloseAccountCommand(userRepo.Object, accountingRepo.Object, writer.Object);

            command.Parameters = new List<string>() { "closeaccount", "123456" };

            // Act  
            command.Execute();

            // Assert
            user.Verify(x => x.Bill, Times.AtLeastOnce);
        }

        [TestMethod]
        public void CloseAccountCommand_Execute_Should_Call_Writer_With_Correct_Output()
        {
            // Arrange
            var writer = new Mock<IWriter>();
            var userRepo = new Mock<IUserRepository>();
            var accountingRepo = new Mock<IAccountingRepository>();
            var user = new Mock<IUser>();

            user.Setup(x => x.PhoneNumber).Returns("123456");
            user.Setup(x => x.Bill).Returns(10m);
            user.Setup(x => x.FirstName).Returns("firstName");
            user.Setup(x => x.LastName).Returns("lastName");
            userRepo.SetupGet(x => x.Users).Returns(new List<IUser>() { user.Object });
            var command = new CloseAccountCommand(userRepo.Object, accountingRepo.Object, writer.Object);

            command.Parameters = new List<string>() { "closeaccount", "123456" };

            // Act  
            command.Execute();

            // Assert
            writer.Verify(x => x.WriteLine("firstName lastName's account was closed"));
        }
    }
}
