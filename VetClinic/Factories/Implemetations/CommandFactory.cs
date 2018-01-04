namespace VetClinic.Factories.Implemetations
{
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Models;
    using VetClinic.Factories.Contracts;

    public class CommandFactory : ICommandFactory
    {
        public IEngineCommand CreateCommand(string name) => new EngineCommand(name);
    }
}
