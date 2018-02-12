using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Core.Commands.Implementations.AccountingCommands;
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
    }
}
