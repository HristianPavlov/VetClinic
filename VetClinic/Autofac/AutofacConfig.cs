namespace VetClinic.Autofac
{
    using global::Autofac;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public static class AutofacConfig
    {
        public static IContainer RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);

            return builder.Build();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            // register components
            builder
                .RegisterAssemblyTypes(typeof(ICommand).Assembly)
                .Where(t => t.Name.EndsWith("Command"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterAssemblyTypes(typeof(ICommandFactory).Assembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
              .RegisterAssemblyTypes(typeof(IRepository).Assembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces()
              .SingleInstance();

            builder.RegisterType<VetClinicEventHandler>().SingleInstance();

            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

        }
    }
}
