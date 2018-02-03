namespace VetClinic.Factories.Implemetations
{
    using Autofac;
    using VetClinic.Data.Contracts;
    using VetClinic.Factories.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext container;

        public CommandFactory(IComponentContext container)
        {
            this.container = container;
        }

        public IEngineCommand CreateCommand(string name)
            => this.container.ResolveNamed<IEngineCommand>(name);
    }
}
