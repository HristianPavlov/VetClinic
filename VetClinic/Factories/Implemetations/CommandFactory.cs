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
        private readonly IComponentContext context;


        public CommandFactory(IComponentContext context)
        {
            this.context = context;
        }

        // TODO dynamically return the right class (or call the method of class)
        public object GetCommandClass(string commandAsString)
            => this.context.ResolveNamed<object>(commandAsString.Split(' ')[0]);

        public List<Type> GetCommandClasses()
        => Assembly
               .Load("VetClinic.Core")
              .GetTypes()
              .Where(t => t.IsClass && t.Name.EndsWith("Command"))
              .Distinct()
              .ToList();
    }
}
