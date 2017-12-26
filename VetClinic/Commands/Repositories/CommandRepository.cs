namespace VetClinic.Commands.Repositories
{
    using System;
    using System.Collections.Generic;
    using VetClinic.Commands.Contracts;

    public class CommandRepository : ICommandRepository
    {
        private readonly ICollection<IUserCommand> commands;

        public CommandRepository()
        {
            this.commands = new List<IUserCommand>();
        }

        public ICollection<IUserCommand> Commands => new List<IUserCommand>(this.commands);

        public void AddComamnd(IUserCommand command)
        {
            throw new NotImplementedException();
        }

        public IUserCommand GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void ListAllCommands()
        {
            throw new NotImplementedException();
        }

        public void RemoveCommand(string name)
        {
            throw new NotImplementedException();
        }
    }
}
