using VetClinic.Commands.Contracts;

namespace VetClinic.Factories.Contracts
{
    public interface ICommandFactory
    {
        // TODO
        ICommand CreateCommand(string commandAsString);
    }
}
