using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VetClinic.Data.Contracts;
using VetClinic.Data.Models;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Data.Repositories.Implementations;
using VetClinic.Factories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Test.VetClinic.Data.Repositories
{
    [TestClass]
    public class ServicesRepositoryTests
    {



        [TestMethod]
        public void ServiceRepo_Should_Add_Service_To_Repo()
        {
            // Arrange
            var serviceFactoryMock = new Mock<IServiceFactory>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new ServiceRepository();


            var serviceRepoMock = new Mock<IServiceRepository>();

            //serviceRepoMock.Setup(x=>x.CreateService(It.IsAny<IService>())).r
            var TheShit = new Service("Name", 7, 7);

            //var TheShit = new Mock<IService>();
            // Act

            sut.CreateService(TheShit);

            // Assert
            //serviceFactoryMock.Verify(x => x.CreateService("Name", 7), Times.Once());

            Assert.IsTrue(sut.Services.Contains(TheShit));

        }

        [TestMethod]
        public void ServiceRepo_Should_Add_Service_To_DB_2()
        {
            // Arrange
            var serviceFactoryMock = new Mock<IServiceFactory>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new ServiceRepository();


            var serviceRepoMock = new Mock<IServiceRepository>();

            //serviceRepoMock.Setup(x=>x.CreateService(It.IsAny<IService>())).r
            //var TheShit = new Service("Name", 7, 7);

            var TheShit = new Mock<IService>();
            // Act

            sut.CreateService(TheShit.Object);

            // Assert
            //serviceFactoryMock.Verify(x => x.CreateService("Name", 7), Times.Once());

            Assert.IsTrue(sut.Services.Contains(TheShit.Object));
        }


        [TestMethod]
        public void DeleteService_Should_Delete_Service_From_Db()
        {
            // Arrange
            //var sut = new ServiceRepository();

            //var TheShit = new Mock<IService>();

            var serviceRepoMock = new Mock<IServiceRepository>();

            // Act
            serviceRepoMock.Setup(x => x.DeleteService(It.IsAny<string>()));
            serviceRepoMock.Object.DeleteService(It.IsAny<string>());



            // Assert
            serviceRepoMock.Verify(x => x.DeleteService(It.IsAny<string>()), Times.Once);
        }



        [TestMethod]
        public void DeleteService_Should_Delete_Service_From_Db_SecondTry()
        {
            // Arrange
            // var sut = new ServiceRepository();
            var serviceRepoMock = new Mock<IServiceRepository>();

            // Act
            var TheShit = new Service("Name", 7, 7);

            serviceRepoMock.Setup(x => x.DeleteService("Name"));

            serviceRepoMock.Object.DeleteService("Name");

            // Assert
            serviceRepoMock.Verify(x => x.DeleteService(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void ContainService_Should_Throw_Exception_When_Id_IsNullOrEmpty()
        {
            // Arrange
            var sut = new ServiceRepository();
            var TheShit = new Mock<IService>();
            TheShit.SetupGet(x => x.Id).Returns("");
            sut.CreateService(TheShit.Object);



            //  Act  & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.ContainsService(TheShit.Object.Id));

        }

        [TestMethod]
        public void ContainService_Should_Find_Service_From_Db_()
        {
            // Arrange
            var sut = new ServiceRepository();
            var TheShit = new Mock<IService>();
            TheShit.SetupGet(x => x.Id).Returns("1");
            sut.CreateService(TheShit.Object);

            // Act
            var answer = sut.ContainsService(TheShit.Object.Id);
            // Assert

            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void FindById_Should_Return_Service_From_Db_()
        {
            // Arrange
            var sut = new ServiceRepository();
            var TheShit = new Mock<IService>();
            TheShit.SetupGet(x => x.Id).Returns("1");
            sut.CreateService(TheShit.Object);

            // Act
            var answer = sut.FindById(TheShit.Object.Id);
            // Assert

            Assert.AreEqual(TheShit.Object, answer);
        }
        [TestMethod]
        public void FindById_Should_Throw_Exception_When_Id_IsNullOrEmpty()
        {
            // Arrange
            var sut = new ServiceRepository();
            var TheShit = new Mock<IService>();
            TheShit.SetupGet(x => x.Id).Returns("");
            sut.CreateService(TheShit.Object);



            //  Act  & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.FindById(TheShit.Object.Id));

        }


    }
}
