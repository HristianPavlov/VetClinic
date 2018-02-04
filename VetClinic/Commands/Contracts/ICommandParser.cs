using System.Collections.Generic;

namespace VetClinic.Core.Commands.Contracts
{
    public interface ICommandParser
    {
        //string ParseCommand(string commandAsString);

        IList<string> ParseParameters(string commandAsString);
    }
}
