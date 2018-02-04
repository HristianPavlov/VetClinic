using System.Collections.Generic;

namespace VetClinic.Core.Commands.Contracts
{
    public interface ICommandParser
    {
        IList<string> ParseParameters(string commandAsString);
    }
}
