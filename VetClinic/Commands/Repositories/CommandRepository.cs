namespace VetClinic.Commands.Repositories
{
    using System;
    using System.Collections.Generic;
    using VetClinic.Commands.Contracts;

    public class CommandRepository : ICommandRepository
    {
        private readonly ICollection<ICommandExample> commands;

        public CommandRepository()
        {
            this.commands = new List<ICommandExample>();
        }

        public ICollection<ICommandExample> Commands => new List<ICommandExample>(this.commands);

        public void AddComamnd(ICommandExample command)
        {
            throw new NotImplementedException();
        }

        public ICommandExample GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveCommand(string name)
        {
            throw new NotImplementedException();
        }
    }
}
