using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VetClinic.Commands.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.CommandCommands
{
    public class ListCommandsCommand : AbstractCommand, ICommand
    {
        private readonly IWriter writer;

        public ListCommandsCommand(IWriter writer)
        {
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            ListCommands();
        }

        private void ListCommands()
        {
            var commandsList = this.GetAllCommandNames();

            if (commandsList == null)
            {
                throw new ArgumentNullException("No commands created yet");
            }

            this.writer.WriteLine(("All commands:"));
            var counter = 0;

            foreach (var command in commandsList.Skip(1))
            {
                this.writer.WriteLine($"{++counter}. {command}");
            }
        }

        private IEnumerable<string> GetAllCommandNames()
        {
            var assembly = Assembly.GetAssembly(typeof(ICommand));
            var types = assembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(i => i == typeof(ICommand))).ToList();

            var result = new List<string>();

            foreach (var type in types)
            {
                string commandName = type.Name.Substring(0, type.Name.Length - "Command".Length);
                result.Add(commandName);
            }

            return result;
        }
    }
}
