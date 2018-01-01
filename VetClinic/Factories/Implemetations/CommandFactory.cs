namespace VetClinic.Factories.Implemetations
{
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Models;
    using VetClinic.Factories.Contracts;

    public class CommandFactory : Factory, ICommandFactory
    {
        public IEngineCommand CreateCommand(string name) => new EngineCommand(name);
    }
}
