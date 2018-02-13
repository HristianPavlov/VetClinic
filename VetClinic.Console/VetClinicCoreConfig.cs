namespace VetClinic.Console
{
    using Autofac;
    using Autofac.Extras.DynamicProxy;
    using System.Configuration;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Console.Interceptors;
    using VetClinic.Core.Commands.Implementations.AccountingCommands;
    using VetClinic.Core.Commands.Implementations.CommandCommands;
    using VetClinic.Core.Commands.Implementations.EmployeeCommands;
    using VetClinic.Core.Commands.Implementations.PetCommands;
    using VetClinic.Core.Commands.Implementations.ServiceCommands;
    using VetClinic.Core.Commands.Implementations.UserCommands;

    public class VetClinicCoreConfig : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
                .Where(x => x.Namespace.Contains("Commands") ||
                            x.Namespace.Contains("Factories") ||
                            x.Namespace.Contains("Providers") ||
                            x.Name.EndsWith("Engine"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ContainerBuilder>().AsSelf().SingleInstance();

            // COMMANDS:
            // UserCommands
            builder.RegisterType<CreateUserCommand>().Named<ICommand>("createuser").SingleInstance();
            builder.RegisterType<DeleteUserCommand>().Named<ICommand>("deleteuser").SingleInstance();
            builder.RegisterType<SearchUserByPhoneCommand>().Named<ICommand>("searchuserbyphone").SingleInstance();
            builder.RegisterType<ListUsersCommand>().Named<ICommand>("listusers").SingleInstance();
            builder.RegisterType<ListUserPetsCommand>().Named<ICommand>("listuserpets").SingleInstance();

            // EmployeeCommands
            builder.RegisterType<CreateEmployeeCommand>().Named<ICommand>("createemployee").SingleInstance();
            builder.RegisterType<DeleteEmployeeCommand>().Named<ICommand>("deleteemployee").SingleInstance();
            builder.RegisterType<SearchEmployeeByPhoneCommand>().Named<ICommand>("searchemployeebyphone").SingleInstance();
            builder.RegisterType<ListEmployeesCommand>().Named<ICommand>("listemployees");

            // PetCommands
            builder.RegisterType<CreatePetCommand>().Named<ICommand>("createpet").SingleInstance();
            builder.RegisterType<DeletePetCommand>().Named<ICommand>("deletepet").SingleInstance();
            builder.RegisterType<ListPetsCommand>().Named<ICommand>("listpets").SingleInstance();

            // ServicesCommands
            builder.RegisterType<CreateServiceCommand>().Named<ICommand>("createservice").SingleInstance();
            builder.RegisterType<DeleteServiceCommand>().Named<ICommand>("deleteservice").SingleInstance();
            builder.RegisterType<PerformServiceCommand>().Named<ICommand>("performservice").SingleInstance();
            builder.RegisterType<ListServicesCommand>().Named<ICommand>("listservices").SingleInstance();

            // CommandsCommands
            builder.RegisterType<ListCommandsCommand>().Named<ICommand>("listcommands").SingleInstance();

            // AccountingCommands
            builder.RegisterType<CloseAccountCommand>().Named<ICommand>("closeaccount").SingleInstance();
            builder.RegisterType<PrintBalanceCommand>().Named<ICommand>("printbalance").SingleInstance();


            bool isTest = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

            if (isTest)
            {
                // StopwatchInterceptor
                builder.RegisterType<StopwatchInterceptor>().AsSelf();

                // Engine with StopwatchInterceptor
                builder.RegisterType<Engine>()
                    .As<IEngine>()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(StopwatchInterceptor));
            }
        }
    }
}
