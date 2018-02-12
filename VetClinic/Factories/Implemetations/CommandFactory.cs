namespace VetClinic.Factories.Implemetations
{
    using Autofac;
    using VetClinic.Commands.Contracts;
    using VetClinic.Factories.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext container;

        public CommandFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommand CreateCommand(string name)
            => this.container.ResolveNamed<ICommand>(name);
    }
}
