namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Factories.Contracts;
    using VetClinic.Providers.Contracts;

    public class Command : ICommand
    {
        private readonly ICommandFactory commandFactory;
        private readonly IWriter writer;

        public Command(ICommandFactory commandFactory, IWriter writer)
        {
            this.commandFactory = commandFactory;
            this.writer = writer;
        }

        public void ListCommands()
        {
            var commandsList = this.GetAllCommandNames();

            if (commandsList == null)
            {
                throw new ArgumentNullException("No commands created yet");
            }

            this.writer.WriteLine(("All commands:"));
            var counter = 0;

            foreach (var commands in commandsList.Skip(1))
            {
                foreach (var command in commands)
                {
                    this.writer.WriteLine($"{++counter}. {command.Name}");
                }
            }
        }

        private IEnumerable<List<MethodInfo>> GetAllCommandNames()
             => Assembly
                    .Load("VetClinic.Core")
                   //.GetAssembly(typeof(IEngineCommand))
                   .GetTypes()
                   .Where(t => t.IsInterface && t.Name.EndsWith("Command"))
                   .Select(t => t.GetMethods().Where(m => m.ReturnType == typeof(void))
                   .Distinct()
                   .ToList());
    }
}
