using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Core.Commands.Contracts;
using VetClinic.Factories.Contracts;

namespace VetClinic.Core.Commands.Implementations
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory ?? throw new ArgumentNullException();
        }

        public IEngineCommand ParseCommand(string commandLine)
        {
            var commandParts = commandLine.Trim().Split(new[] { ' ', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();


            var commandName = commandParts[0].ToLower();
            var command = this.commandFactory.CreateCommand(commandName);
            return command;
        }
    }
}
