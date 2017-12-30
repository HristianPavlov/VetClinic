namespace VetClinic
{
    using Autofac;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common;
    using VetClinic.Data.Models.Abstractions;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public static class AutofacContainer
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
              .RegisterAssemblyTypes(typeof(IRepository).Assembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces()
              .SingleInstance();

            builder
                .RegisterAssemblyTypes(typeof(ICommandFactory).Assembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterAssemblyTypes(typeof(ICommand).Assembly)
                .Where(t => t.Name.EndsWith("Command"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<VetClinicEventHandler>().SingleInstance();

            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                 .AssignableTo<Person>().PropertiesAutowired();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                 .AssignableTo<Pet>().PropertiesAutowired();
        }
    }
}
