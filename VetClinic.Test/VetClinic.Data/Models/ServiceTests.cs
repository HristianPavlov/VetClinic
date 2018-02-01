using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Data.Contracts;
using VetClinic.Data.Enums;
using VetClinic.Data.Models;

namespace VetClinic.Test.VetClinic.Data.Models
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void Constructor_Service_Should_Throw_ArgumentNullException_When_Name_Is_Null()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Service(null));
        }

        [TestMethod]
        public void Constructor_Service_Should_Throw_ArgumentNullException_When_TimeToExecute_Is_Negaative()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Service("gangsta",-1));
        }

        [TestMethod]
        public void Constructor_Service_Should_Throw_ArgumentNullException_When_Price_Is_Negative()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Service("gangsta",-1, 1));
        }

        [TestMethod]
        public void Constructor_Service_Should_Throw_ArgumentNullException_When_Price_Is_Zero()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Service("gangsta", 0,6));
        }

        [TestMethod]
        public void Constructor_Should_Create_New_Intsnace_Of_Class_Service()
        {
            // Arrange & Act
            var service = new Service("name", 1);

            // Assert
            Assert.IsNotNull(service);
            Assert.IsInstanceOfType(service, typeof(Service));
        }


        // Methods
        [TestMethod]
        public void AddService_Should_Add_New_Pet_To_ServicesList()
        {
            // Arrange
            var serviceList = new List<IService>();
            var service = new Mock<IService>();

            // Act
            serviceList.Add(service.Object);

            //Assert
            Assert.AreEqual(1, serviceList.Count);
        }

        [TestMethod]
        public void RemoveService_Should_Remove_Pet_From_ServicesList()
        {
            // Arrange
            var serviceList = new List<IService>();
            var service = new Mock<IService>();
            serviceList.Add(service.Object);

            // Act
            serviceList.Remove(service.Object);

            // Assert
            Assert.AreEqual(0, serviceList.Count);
        }

        //[TestMethod]
        //public void Service_Should_Execute_As_Expected()
        //{
        //    // Arrange
            
        //    var service = new Mock<IService>();
        //    serviceList.Add(pet.Object);

        //    // Act
        //    serviceList.Remove(pet.Object);

        //    // Assert
        //    Assert.AreEqual(0, serviceList.Count);
        //}


        [TestMethod]
        public void PrintInfo_Service_Should_Return_String_In_Correct_Format()
        {
            // Arrange
            var service = new Service("Name");

            // Act
            var printedInfo = service.PrintInfo();
            var expectedResult = string.Format(
                              $"Name: {service.Name}" + Environment.NewLine +
                              $"Id: {service.Id}" + Environment.NewLine +
                              $"Price: {service.Price}") + Environment.NewLine;
                             
            // Assert
            Assert.AreEqual(expectedResult, printedInfo);
        }
    }
}

  