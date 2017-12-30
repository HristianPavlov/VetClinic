namespace VetClinic.Factories.Contracts
{
    using VetClinic.Data.Contracts;

    public interface ICommandFactory
    {
        IEngineCommand CreateCommand(string name);
    }
}
