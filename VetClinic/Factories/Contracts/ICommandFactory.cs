namespace VetClinic.Factories.Contracts
{
    using VetClinic.Commands.Contracts;

    public interface ICommandFactory
    {
        IEngineCommand CreateCommand(string name);
    }
}
