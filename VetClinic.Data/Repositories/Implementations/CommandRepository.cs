namespace VetClinic.Data.Repositories.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandRepository : ICommandRepository
    {
        private readonly ICollection<IEngineCommand> commands;

        public CommandRepository()
        {
            this.commands = new List<IEngineCommand>();
        }

        public ICollection<IEngineCommand> Commands => new List<IEngineCommand>(this.commands);

        public void CreateCommand(IEngineCommand command)
        {
            var commandExists = this.commands.Any(s => s.Id == command.Id);

            if (commandExists)
            {
                throw new Exception("This command already exists!");
            }

            this.commands.Add(command);
        }

        public void DeleteCommand(string name)
        {
            var command = this.commands.SingleOrDefault(s => s.Name == name);

            if (command == null)
            {
                throw new Exception("No such command found!");
            }

            this.commands.Remove(command);
        }

        public IEngineCommand GetByName(string name) => this.commands.SingleOrDefault(s => s.Name == name);

        public string ListCommands()
        {
            var sb = new StringBuilder();

            foreach (var command in this.commands)
            {
                sb.AppendLine($"{command.PrintInfo()}");
            }

            return sb.ToString();
        }
    }
}
