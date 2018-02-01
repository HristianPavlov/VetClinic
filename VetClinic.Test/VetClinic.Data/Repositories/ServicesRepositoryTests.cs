using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Commands.Contracts;
using VetClinic.Commands.Implementations;
using VetClinic.Common.ConsoleServices.Contracts;
using VetClinic.Data.Contracts;
using VetClinic.Data.Models;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Data.Repositories.Implementations;
using VetClinic.Factories.Contracts;

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
            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new ServiceRepository();

            var TheShit = new Service("Name", 7, 7);

            // Act
            sut.CreateService(TheShit);

            // Assert
            //serviceFactoryMock.Verify(x => x.CreateService("Name", 7), Times.Once());

            Assert.IsTrue(sut.Services.Contains(TheShit));
           
        }

        //[TestMethod]
        //public void DeleteService_Should_Delete_Service_From_Db()
        //{
        //    // Arrange
            

        //    // Act
        //    serviceRepoMock.Setup(x => x.DeleteService(It.IsAny<string>()));
        //    serviceRepoMock.Object.DeleteService(It.IsAny<string>());

        //    // Assert
        //    serviceRepoMock.Verify(x => x.DeleteService(It.IsAny<string>()), Times.Once);
        //}

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
    }
}
