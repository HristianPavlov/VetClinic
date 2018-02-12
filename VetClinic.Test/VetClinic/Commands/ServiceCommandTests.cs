//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System.Collections.Generic;
//using VetClinic.Commands.Contracts;
//using VetClinic.Commands.Implementations;
//using VetClinic.Data.Contracts;
//using VetClinic.Data.Repositories.Contracts;
//using VetClinic.Factories.Contracts;
//using VetClinic.Providers.Contracts;

//namespace VetClinic.Test.VetClinic.Commands
//{
//    [TestClass]
//    public class ServiceCommandTests
//    {
//        private static IServiceCommand GetServiceCommand()
//        {
//            var serviceFactoryMock = new Mock<IServiceFactory>();
//            var serviceRepoMock = new Mock<IServiceRepository>();
//            var userMock = new Mock<IUserRepository>();
//            var writerMock = new Mock<IWriter>();

//            var sut = new ServiceCommand(serviceFactoryMock.Object, serviceRepoMock.Object, userMock.Object, writerMock.Object);

//            return sut;

//        }

//        // Constructor
//        [TestMethod]
//        public void Constructor_Should_Return_New_Instance_Of_Class_ServiceCommand()
//        {

//            // Arrange
//            var sut = GetServiceCommand();

//            // Assert
//            Assert.IsInstanceOfType(sut, typeof(ServiceCommand));
//        }

//        [TestMethod]
//        public void CreateService_Should_Call_ServiceFactory()
//        {
//            // Arrange
//            var serviceFactoryMock = new Mock<IServiceFactory>();
//            var serviceRepoMock = new Mock<IServiceRepository>();
//            var userMock = new Mock<IUserRepository>();
//            var writerMock = new Mock<IWriter>();

//            var sut = new ServiceCommand(serviceFactoryMock.Object, serviceRepoMock.Object, userMock.Object, writerMock.Object);
//            serviceRepoMock.SetupGet(x => x.Services).Returns(new List<IService>());
//            serviceFactoryMock.Setup(x => x.CreateService(It.IsAny<string>(), It.IsAny<decimal>())).Verifiable();


//            // var serviceFactoryMock = new Mock<IServiceFactory>();
//            var parameters = new List<string>()
//            {   "",
//                "Name",
//                "7"
//            };


//            // Act
//            sut.CreateService(parameters);

//            // Assert
//            serviceFactoryMock.Verify(x => x.CreateService("Name", 7), Times.Once());
//        }
//    }
//}
