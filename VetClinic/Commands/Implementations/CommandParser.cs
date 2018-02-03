using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<string> ParseCommand(string commandLine)
        {
            return commandLine.Trim().Split(new[] { ' ', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        }
    }
}
