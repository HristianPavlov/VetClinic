namespace VetClinic.Factories.Implemetations
{
    using Autofac;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using VetClinic.Factories.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext container;


        public CommandFactory(IComponentContext context)
        {
            this.container = context;
        }

        // TODO dynamically return the right class (or call the method of class)
        public object ResolveCommand(string commandAsString)
            => this.container.ResolveNamed<object>(commandAsString);

        public List<Type> GetAllCommands()
        => Assembly
               .Load("VetClinic.Core")
               .GetTypes()
               .Where(t => t.IsInterface && t.Name == "ProcessorCommand")
               .Distinct()
               .ToList();
    }
}
