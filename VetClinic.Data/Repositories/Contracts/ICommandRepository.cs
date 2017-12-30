namespace VetClinic.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface ICommandRepository
    {
        ICollection<IEngineCommand> Commands { get; }

        IEngineCommand GetByName(string name);

        void CreateCommand(IEngineCommand command);

        void DeleteCommand(string name);

        string ListCommands();
    }
}