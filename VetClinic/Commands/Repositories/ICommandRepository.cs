namespace VetClinic.Commands.Repositories
{
    using System.Collections.Generic;
    using VetClinic.Commands.Contracts;

    public interface ICommandRepository
    {
        ICollection<ICommandExample> Commands { get; }

        ICommandExample GetByName(string name);

        void AddComamnd(ICommandExample command);

        void RemoveCommand(string name);
    }
}