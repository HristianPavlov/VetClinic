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
using VetClinic.Data.Enums;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;

namespace VetClinic.Test.VetClinic.Commands
{
    [TestClass]
  public  class ServiceCommandTests
    {


        private static IServiceCommand GetServiceCommand()
        {
            var serviceFactoryMock = new Mock<IServiceFactory>();
            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new ServiceCommand(serviceFactoryMock.Object, serviceRepoMock.Object, userMock.Object, writerMock.Object);


            return sut;

        }

        // Constructor
        [TestMethod]
        public void Constructor_Should_Return_New_Instance_Of_Class_ServiceCommand()
        {

            // Arrange
            var sut = GetServiceCommand();
                    
            // Assert
            Assert.IsInstanceOfType(sut, typeof(ServiceCommand));
        }
        
        [TestMethod]
        public void CreateService_Should_Call_ServiceFactory()
        {
            // Arrange
            var serviceFactoryMock = new Mock<IServiceFactory>();
            var serviceRepoMock = new Mock<IServiceRepository>();
            var userMock = new Mock<IUserRepository>();
            var writerMock = new Mock<IWriter>();

            var sut = new ServiceCommand(serviceFactoryMock.Object, serviceRepoMock.Object, userMock.Object, writerMock.Object);
            serviceRepoMock.SetupGet(x=>x.Services).Returns(new List<IService>());
            serviceFactoryMock.Setup(x => x.CreateService(It.IsAny<string>(), It.IsAny<decimal>())).Verifiable();
                           

            // var serviceFactoryMock = new Mock<IServiceFactory>();
            var parameters = new List<string>()
            {   "",
                "Name",
                "7"
            };


            // Act
            sut.CreateService(parameters);
            
            // Assert
            serviceFactoryMock.Verify(x => x.CreateService("Name", 7), Times.Once());
        }


       


      

    }
}






//public void ListServices(IList<string> parameters)
//{
//    if (this.services.Services.Count == 0)
//    {
//        throw new ArgumentException("No users registered");
//    }

//    var sb = new StringBuilder();

//    sb.AppendLine("All services:");

//    foreach (var service in this.services.Services)
//    {
//        sb.AppendLine(service.PrintInfo());
//    }

//    this.writer.WriteLine(sb.ToString());
//}

//public void PerformService(IList<string> parameters)
//{
//    var serviceName = parameters[1];
//    var userPhone = parameters[2];
//    var animalName = parameters[3];

//    var service = this.services.Services.SingleOrDefault(s => s.Name == serviceName);

//    if (service == null)
//    {
//        throw new ArgumentNullException($"{serviceName} is not found.");
//    }

//    var user = this.users.Users.SingleOrDefault(u => u.PhoneNumber == userPhone);

//    if (user == null)
//    {
//        throw new ArgumentNullException($"{user.FirstName} {user.LastName} does not exists");
//    }

//    IPet pet = user.Pets.SingleOrDefault((p => p.Name == animalName));

//    if (pet == null)
//    {
//        throw new ArgumentNullException($"{user.FirstName} {user.LastName} does not have an pet with name: {animalName} registered. Please register {animalName} for customer {user.FirstName} {user.LastName} first");
//    }

//    pet.AddServices(service);
//    user.Bill += service.Price;

//    service.Execute();
//    this.writer.WriteLine($"Service {service.Name} completed!");
//}

//public decimal CloseAccount(IList<string> parameters)
//{
//    var userPhone = parameters[1];
//    var user = this.users.Users.SingleOrDefault(u => u.PhoneNumber == userPhone);

//    decimal amount = user.Bill;
//    user.Bill = 0;

//    return amount;
//}


//public void BookService(IList<string> parameters)
//{
//    var name = parameters[1];

//    var service = this.services.Services.SingleOrDefault(p => p.Name == name);

//    if (service == null)
//    {
//        throw new ArgumentNullException("Service not found");
//    }
//    this.writer.WriteLine($"Service {service.Name} completed!");
//}