using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VetClinic.Factories.Implemetations;

namespace VetClinic.Test.VetClinic.Factories
{
    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Container_Is_Null()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandFactory(null));
        }
    }
}
