namespace VetClinic.Console
{
    using Autofac;
    using System.Configuration;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Commands.Implementations;

    public class AutofacModuleConfig : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            // Assembly.GetAssembly(typeof(IEngine))) 
            builder.RegisterAssemblyTypes(Assembly.Load("VetClinic.Core"))
                .Where(x => x.Namespace.Contains("Commands") ||
                            x.Namespace.Contains("Factories") ||
                            x.Namespace.Contains("Providers") ||
                            x.Name.EndsWith("Engine"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.Load("VetClinic.Data"))
                .Where(x => x.Namespace.Contains("Repositories"))
                .AsImplementedInterfaces()
                .SingleInstance();

            bool isTest = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

            if (isTest)
            {
                builder.RegisterType<UserCommand>().Named<IUserCommand>("createuser");
                builder.RegisterType<UserCommand>().Named<IUserCommand>("deleteuser");
                builder.RegisterType<UserCommand>().Named<IUserCommand>("listuserpets");
                builder.RegisterType<UserCommand>().Named<IUserCommand>("searchuserbyphone");
                builder.RegisterType<UserCommand>().Named<IUserCommand>("listusers");

                builder.RegisterType<EmployeeCommand>().Named<IEmployeeCommand>("createemployee");
                builder.RegisterType<EmployeeCommand>().Named<IEmployeeCommand>("deleteemployee");
                builder.RegisterType<EmployeeCommand>().Named<IEmployeeCommand>("listemployees");
                builder.RegisterType<EmployeeCommand>().Named<IEmployeeCommand>("searchemployeebyphone");

                builder.RegisterType<PetCommand>().Named<IPetCommand>("createpet");
                builder.RegisterType<PetCommand>().Named<IPetCommand>("deletepet");
                builder.RegisterType<PetCommand>().Named<IPetCommand>("listpets");

                builder.RegisterType<ServiceCommand>().Named<IServiceCommand>("createservice");
                builder.RegisterType<ServiceCommand>().Named<IServiceCommand>("deleteservice");
                builder.RegisterType<ServiceCommand>().Named<IServiceCommand>("listservices");
                builder.RegisterType<ServiceCommand>().Named<IServiceCommand>("performservice");

                builder.RegisterType<EngineCommand>().Named<IEngineCommand>("listcommands");

                builder.RegisterType<CashRegisterCommand>().Named<ICashRegisterCommand>("updatebalance");
                builder.RegisterType<CashRegisterCommand>().Named<ICashRegisterCommand>("printbalance");
                builder.RegisterType<CashRegisterCommand>().Named<ICashRegisterCommand>("printbookedservices");

            }
            else
            {
                builder.RegisterType<EngineCommand>().Named<IEngineCommand>("listcommands");
                builder.RegisterType<EngineCommand>().Named<IEngineCommand>("listcommands")
                    .WithParameter(
                    (pi, ctx) => pi.Name == "command",
                    (pi, ctx) => ctx.ResolveNamed<IEngineCommand>("listcommands"));
            }

            builder.RegisterType<ContainerBuilder>().AsSelf().SingleInstance();
        }
    }
}
