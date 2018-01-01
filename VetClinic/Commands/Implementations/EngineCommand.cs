namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common;
    using VetClinic.Common.ConsoleServices.Contracts;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public class EngineCommand : VetClinicEventHandler, IEngineCommand
    {
        private readonly ICommandFactory commandFactory;
        private readonly ICommandRepository commandsDb;
        private readonly ICommand commands;
        private readonly IWriter writer;

        public EngineCommand(ICommandFactory commandFactory, ICommandRepository commandsDb, ICommand commands, IWriter writer)
        {
            this.commandFactory = commandFactory;
            this.commandsDb = commandsDb;
            this.writer = writer;
            this.commands = commands;
        }
        public void CreateCommand(IList<string> parameters)
        {
            var name = parameters[1];

            var newCommand = this.commandFactory.CreateCommand(name);

            this.commandsDb.CreateCommand(newCommand);
            this.OnMessage($"Command {name} successfully created");
        }

        public void DeleteCommand(IList<string> parameters)
        {
            var name = parameters[1];

            var command = this.commandsDb.Commands.FirstOrDefault(p => p.Name == name);

            if (command == null)
            {
                throw new ArgumentException("Command not found");
            }

            this.commandsDb.DeleteCommand(name);
            this.OnMessage($"Command {name} successfully deleted");
        }

        public void ListCommands()
        {
            var engineCommands = this.commands.GetAllCommands();

            if (engineCommands == null)
            {
                throw new ArgumentException("No commands created yet");
            }

            this.writer.WriteLine(("All commands:"));
            var counter = 0;

            foreach (var command in engineCommands)
            {
                if ( command.ToLower() == "write" ||
                     command.ToLower() == "writeline" ||
                     command.ToLower() == "addbokedservice" ||
                     command.ToLower() == "processcommand" ||
                     command.ToLower() == "createcommand" ||
                     command.ToLower() == "deletecommand" ||
                     command.ToLower() == "bookservice" )
                { }
                else
                {
                    this.writer.WriteLine($"{++counter}. {command}");
                }
            }
        }
    }
}
