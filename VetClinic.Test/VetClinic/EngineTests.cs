using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VetClinic.Commands.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Test.VetClinic
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_CommandProcessor_Is_Null()
        {
            // Arrange
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(null, reader.Object, writer.Object));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Reader_Is_Null()
        {
            // Arrange
            var commandProcessor = new Mock<ICommandProcessor>();
            var writer = new Mock<IWriter>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(commandProcessor.Object, null, writer.Object));
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_Writer_Is_Null()
        {
            // Arrange
            var commandProcessor = new Mock<ICommandProcessor>();
            var reader = new Mock<IReader>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine(commandProcessor.Object, reader.Object, null));
        }

        [TestMethod]
        public void Constructor_Should_Call_Reader_ReadLineMethod()
        {
            // Arrange
            var commandProcessor = new Mock<ICommandProcessor>();
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            var engine = new Engine(commandProcessor.Object, reader.Object, writer.Object);

            reader.SetupSequence(m => m.ReadLine()).Returns("listcommands").Returns("finish");

            // Act
            engine.Run();

            // Assert
            reader.Verify(m => m.ReadLine(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Constructor_Should_Call_Writer_WriteLineMethod_With_StartLine()
        {
            // Arrange
            var commandProcessor = new Mock<ICommandProcessor>();
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            var engine = new Engine(commandProcessor.Object, reader.Object, writer.Object);

            reader.SetupSequence(m => m.ReadLine()).Returns("listcommands").Returns("finish");

            // Act
            engine.Run();

            // Assert
            writer.Verify(m => m.WriteLine(" System running..."), Times.Once);
        }

        [TestMethod]
        public void Constructor_Should_Call_Writer_WriteLineMethod_With_EndLine()
        {
            // Arrange
            var commandProcessor = new Mock<ICommandProcessor>();
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            reader.SetupSequence(m => m.ReadLine()).Returns("listcommands").Returns("finish");

            var engine = new Engine(commandProcessor.Object, reader.Object, writer.Object);

            // Act
            engine.Run();

            // Assert
            writer.Verify(m => m.WriteLine(" Waiting for command..."), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Constructor_Should_Call_Writer_WriteLineMethod_With_Goodbye_When_Line_Is_Finish()
        {
            // Arrange
            var commandProcessor = new Mock<ICommandProcessor>();
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            reader.Setup(m => m.ReadLine()).Returns("finish");

            var engine = new Engine(commandProcessor.Object, reader.Object, writer.Object);

            // Act
            engine.Run();

            // Assert
            writer.Verify(m => m.WriteLine(" Goodbye!"), Times.Once);
            commandProcessor.Verify(m => m.ProcessCommand(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void Constructor_Should_Call_CommandProcessor_ProcessCommandMethod_With_Correct_Line()
        {
            // Arrange
            var commandProcessor = new Mock<ICommandProcessor>();
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            string line = "listcommands";

            reader.SetupSequence(m => m.ReadLine()).Returns(line).Returns("finish");

            var engine = new Engine(commandProcessor.Object, reader.Object, writer.Object);

            // Act
            engine.Run();

            // Assert
            commandProcessor.Verify(m => m.ProcessCommand(line), Times.Once);
        }
    }
}
