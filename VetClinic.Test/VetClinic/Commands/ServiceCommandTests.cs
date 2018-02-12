using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using VetClinic.Commands.Contracts;
using VetClinic.Commands.Implementations;
using VetClinic.Core.Commands.Implementations.ServiceCommands;
using VetClinic.Data.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Test.VetClinic.Commands
{
    [TestClass]
    public class ServiceCommandTests
    {


        private static ICommand GetServiceCommand()
        {
            var serviceFactoryMock = new Mock<IServiceFactory>();
            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new CreateServiceCommand(serviceFactoryMock.Object, serviceRepoMock.Object, writerMock.Object);


            return sut;

        }

        // Constructor
        [TestMethod]
        public void Constructor_Should_Return_New_Instance_Of_Class_ServiceCommand()
        {

            // Arrange
            var sut = GetServiceCommand();

            // Assert
            Assert.IsInstanceOfType(sut, typeof(ICommand));
        }

        [TestMethod]
        public void CreateService_Should_Call_ServiceFactory()
        {
            // Arrange
            var serviceFactoryMock = new Mock<IServiceFactory>();
            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new CreateServiceCommand(serviceFactoryMock.Object, serviceRepoMock.Object, writerMock.Object);
            //

            serviceRepoMock.SetupGet(x => x.Services).Returns(new List<IService>());
            serviceFactoryMock.Setup(x => x.CreateService(It.IsAny<string>(), It.IsAny<decimal>())).Verifiable();


            // var serviceFactoryMock = new Mock<IServiceFactory>();
            var parameters = new List<string>()
            {   "",
                "Name",
                "7"
            };

            sut.Parameters = parameters;
            // Act

            sut.Execute();

            // Assert
            serviceFactoryMock.Verify(x => x.CreateService("Name", 7), Times.Once());

        }

        [TestMethod]
        public void CreateService_Should_Add_ToServiceRepository()
        {
            // Arrange
            var serviceFactoryMock = new Mock<IServiceFactory>();
            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new CreateServiceCommand(serviceFactoryMock.Object, serviceRepoMock.Object, writerMock.Object);
            //
            var list = new List<IService>();
            serviceRepoMock.SetupGet(x => x.Services).Returns(list);

            serviceFactoryMock.Setup(x => x.CreateService(It.IsAny<string>(), It.IsAny<decimal>())).Verifiable();


            // var serviceFactoryMock = new Mock<IServiceFactory>();
            var parameters = new List<string>()
            {   "",
                "Name",
                "7"
            };

            sut.Parameters = parameters;
            // Act

            sut.Execute();


            serviceRepoMock.Verify(x => x.Services, Times.Once());

            // Assert);
        }

        [TestMethod]
        public void CreateService_Should_Throw_ArgumentException_WhenIsAddedExistingService()
        {
            // Arrange
            var serviceFactoryMock = new Mock<IServiceFactory>();
            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new CreateServiceCommand(serviceFactoryMock.Object, serviceRepoMock.Object, writerMock.Object);
            //
            var list = new List<IService>();

            var serviceMock = new Mock<IService>();
            serviceMock.SetupGet(x => x.Name).Returns("Name");

            list.Add(serviceMock.Object);

            serviceRepoMock.SetupGet(x => x.Services).Returns(list);
            serviceFactoryMock.Setup(x => x.CreateService(It.IsAny<string>(), It.IsAny<decimal>())).Verifiable();


            // var serviceFactoryMock = new Mock<IServiceFactory>();
            var parameters = new List<string>()
            {   "",
                "Name",
                "7"
            };

            sut.Parameters = parameters;

            // Act & Assert
            //serviceRepoMock.Verify(x => x.Services, Times.Once());


            Assert.ThrowsException<ArgumentException>(() => sut.Execute());


        }

        [TestMethod]
        public void DeleteService_Should_Throw_ArgumentNullException_WhenServiceDoesNotExist()
        {
            // Arrange

            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new DeleteServiceCommand(serviceRepoMock.Object, writerMock.Object);
            //
            var list = new List<IService>();

            var serviceMock = new Mock<IService>();
            serviceMock.SetupGet(x => x.Name).Returns("Name");

            //list.Add(serviceMock.Object);

            serviceRepoMock.SetupGet(x => x.Services).Returns(list);



            // var serviceFactoryMock = new Mock<IServiceFactory>();
            var parameters = new List<string>()
            {   "",
                "Name",
                "7"
            };

            sut.Parameters = parameters;

            // Act & Assert
            //serviceRepoMock.Verify(x => x.Services, Times.Once());


            Assert.ThrowsException<ArgumentNullException>(() => sut.Execute());


        }

        [TestMethod]
        public void DeleteService_Should_Call_ServiceRepository()
        {
            // Arrange

            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new DeleteServiceCommand(serviceRepoMock.Object, writerMock.Object);
            //
            var list = new List<IService>();

            var serviceMock = new Mock<IService>();
            serviceMock.SetupGet(x => x.Name).Returns("Name");

            list.Add(serviceMock.Object);

            serviceRepoMock.SetupGet(x => x.Services).Returns(list);

            serviceRepoMock.Setup(x => x.DeleteService(It.IsAny<string>()));



            // var serviceFactoryMock = new Mock<IServiceFactory>();
            var parameters = new List<string>()
            {   "",
                "Name",
                "7"
            };

            sut.Parameters = parameters;
            sut.Execute();
            // Act & Assert
            serviceRepoMock.Verify(x => x.DeleteService("Name"), Times.Once());



        }

        [TestMethod]
        public void ListService_Should_Call_ServiceRepository()
        {
            // Arrange

            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new ListServicesCommand(serviceRepoMock.Object, writerMock.Object);
            //
            var list = new List<IService>();

            var serviceMock = new Mock<IService>();
            serviceMock.SetupGet(x => x.Name).Returns("Name");

            list.Add(serviceMock.Object);

            serviceRepoMock.SetupGet(x => x.Services).Returns(list);

            serviceRepoMock.Setup(x => x.DeleteService(It.IsAny<string>()));



            // var serviceFactoryMock = new Mock<IServiceFactory>();
            var parameters = new List<string>()
            {   "",
                "Name",
                "7"
            };

            sut.Parameters = parameters;
            // Act
            sut.Execute();
            //  Assert
            serviceRepoMock.Verify(x => x.Services, Times.Exactly(2));



        }



        [TestMethod]
        public void ListService_Should_Throw_ArgumentException_When_TheRepoIsEmpty()
        {
            // Arrange

            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new ListServicesCommand(serviceRepoMock.Object, writerMock.Object);
            //
            var list = new List<IService>();

            var serviceMock = new Mock<IService>();
            serviceMock.SetupGet(x => x.Name).Returns("Name");

           // list.Add(serviceMock.Object);

            serviceRepoMock.SetupGet(x => x.Services).Returns(list);

            serviceRepoMock.Setup(x => x.DeleteService(It.IsAny<string>()));



            // var serviceFactoryMock = new Mock<IServiceFactory>();
            var parameters = new List<string>()
            {   "",
                "Name",
                "7"
            };

            sut.Parameters = parameters;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }
    }
}




