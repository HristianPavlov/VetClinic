using System.Collections.Generic;

namespace VetClinic.Commands.Contracts
{
    public interface IEngineCommand
    {
        void CreateCommand(IList<string> parameters);

        void DeleteCommand(IList<string> parameters);

        void Help();
    }
}
