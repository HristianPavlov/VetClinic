namespace VetClinic.Factories.Contracts
{
    using VetClinic.Commands.Contracts;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
