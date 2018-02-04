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
            this.commandFactory = commandFactory;
        }

        public IList<string> ParseParameters(string commnandAsString)
        {
            if (string.IsNullOrWhiteSpace(commnandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var commandParts = commnandAsString.Trim().Split(new[] { ' ', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (!commandParts.Any())
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
