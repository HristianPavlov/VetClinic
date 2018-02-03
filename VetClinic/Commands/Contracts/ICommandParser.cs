using System.Collections.Generic;

namespace VetClinic.Core.Commands.Contracts
{
    public interface ICommandParser
    {
        IList<string> ParseCommand(string commandLine);
    }
}
