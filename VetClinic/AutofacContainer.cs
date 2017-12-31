namespace VetClinic
{
    using Autofac;
    using System;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Models.Abstractions;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public class AutofacContainer
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            ConfigureContainer(builder);

            return builder.Build();
        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(ICommandFactory).Assembly)
                .Where(t => t.Name.EndsWith("Repository")
                         && t.Name.EndsWith("Command")
                         && t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<EventHandler>().SingleInstance();

            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

            //builder.RegisterAssemblyTypes(
            //            Assembly.GetExecutingAssembly())
            //           .AssignableTo<Person>()
            //           .PropertiesAutowired();

            //builder.RegisterAssemblyTypes(
            //           Assembly.GetExecutingAssembly())
            //          .AssignableTo<Pet>()
            //          .PropertiesAutowired();
        }
    }
}
