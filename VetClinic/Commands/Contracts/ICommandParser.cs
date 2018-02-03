using VetClinic.Commands.Contracts;

namespace VetClinic.Core.Commands.Contracts
{
    public interface ICommandParser
    {
        IEngineCommand ParseCommand(string commandLine);
    }
}
