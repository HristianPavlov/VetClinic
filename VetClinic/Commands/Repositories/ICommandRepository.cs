namespace VetClinic.Commands.Repositories
{
    using System.Collections.Generic;
    using VetClinic.Commands.Contracts;

    public interface ICommandRepository
    {
        ICollection<IUserCommand> Commands { get; }

        IUserCommand GetByName(string name);

        void AddComamnd(IUserCommand command);

        void RemoveCommand(string name);

        void ListAllCommands();
    }
}