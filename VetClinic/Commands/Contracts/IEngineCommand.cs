namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface IEngineCommand
    {
        void CreateCommand(IList<string> parameters);

        void DeleteCommand(IList<string> parameters);

        //IEnumerable<List<MethodInfo>> GetAllCommands();

        void ListCommands();
    }
}
