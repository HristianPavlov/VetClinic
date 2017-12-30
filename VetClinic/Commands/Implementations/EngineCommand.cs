namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public class EngineCommand : VetClinicEventHandler, IEngineCommand
    {
        private readonly ICommandFactory commandFactory;
        private readonly ICommandRepository commandsDb;

        public EngineCommand(ICommandFactory commandFactory, ICommandRepository commandsDb)
        {
            this.commandFactory = commandFactory;
            this.commandsDb = commandsDb;
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
                Console.WriteLine("Command not found");
                return;
            }

            this.commandsDb.DeleteCommand(name);
            this.OnMessage($"Command {name} successfully deleted");
        }

        public void Help()
        {
            var engineCommands = GetAllCommands();

            if (engineCommands.Count() == 0)
            {
                Console.WriteLine("No commands created yet");
                return;
            }

            Console.WriteLine(("All commands:"));

            foreach (var command in engineCommands)
            {
                Console.WriteLine(command);
            }
        }

        private List<string> GetAllCommands()
        {
            var allCommands = new List<string>();

            var allMethods = Assembly
                        .GetAssembly(typeof(ICommand))
                        .GetTypes()
                        .Where(t => t.IsInterface)
                        .Select(t => new
                         {
                            Commands = t.GetMethods()
                                            .Where(m => m.ReturnType == typeof(void)).ToList()
                          })
                        .ToList();

            foreach (var method in allMethods.Skip(1))
            {
                foreach (var command in method.Commands)
                {
                    allCommands.Add(command.Name);
                }
            }

            return allCommands;
        }
    }
}
