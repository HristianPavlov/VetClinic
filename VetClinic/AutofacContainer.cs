namespace VetClinic
{
    using Autofac;
    using System;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Commands.Implementations;
    using VetClinic.Common.ConsoleServices.Contracts;
    using VetClinic.Common.ConsoleServices.Implementations;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Data.Repositories.Implementations;
    using VetClinic.Factories.Contracts;
    using VetClinic.Factories.Implemetations;

    public class AutofacContainer : Autofac.Module
    {

        //protected override void Load(ContainerBuilder builder)
        //{
        //    builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
        //        //.Where(x=>x.Namespace.Contains("Factories"))
        //        .AsImplementedInterfaces()
        //        .SingleInstance();

        //    builder.RegisterType<ContainerBuilder>().AsSelf().SingleInstance();
        //}

        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            ConfigureContainer(builder);

            return builder.Build();
        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<PetRepository>().As<IPetRepository>().SingleInstance();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();
            builder.RegisterType<ServiceRepository>().As<IServiceRepository>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<CommandRepository>().As<ICommandRepository>().SingleInstance();

            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
            builder.RegisterType<PersonFactory>().As<IPersonFactory>().SingleInstance();
            builder.RegisterType<ServiceFactory>().As<IServiceFactory>().SingleInstance();
            builder.RegisterType<PetFactory>().As<IPetFactory>().SingleInstance();

            builder.RegisterType<UserCommand>().As<IUserCommand>().SingleInstance();
            builder.RegisterType<PetCommand>().As<IPetCommand>().SingleInstance();
            builder.RegisterType<EmployeeCommand>().As<IEmployeeCommand>().SingleInstance();
            builder.RegisterType<ServiceCommand>().As<IServiceCommand>().SingleInstance();
            builder.RegisterType<EngineCommand>().As<IEngineCommand>().SingleInstance();
            builder.RegisterType<CashRegisterCommand>().As<ICashRegisterCommand>().SingleInstance();
            builder.RegisterType<ProcessorCommand>().As<IProcessorCommand>().SingleInstance();

            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();

            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            //builder
            //    .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .SingleInstance();
        }
    }
}
