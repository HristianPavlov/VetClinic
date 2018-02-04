namespace VetClinic.Factories.Implemetations
{
    using Autofac;
    using VetClinic.Factories.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext context;


        public CommandFactory(IComponentContext context)
        {
            this.context = context;
        }

        // TODO dynamically return the right class (or call the method of class)
        public object GetCommandClass(string commandAsString)
            => this.context.ResolveNamed<object>(commandAsString.Split(' ')[0]);


        //private TypeInfo FindCommand(string commandName)
        //{
        //    Assembly assembly = this.GetType().GetTypeInfo().Assembly;
        //    var commandTypeInfo = assembly.DefinedTypes
        //           .Where(t => t.ImplementedInterfaces.Any(i => i == typeof(ICommand)))
        //           .Where(t => t.Name.ToLower() == commandName.ToLower())
        //           .SingleOrDefault();

        //    return commandTypeInfo;
        //}
    }
}
