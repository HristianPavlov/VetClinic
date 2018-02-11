namespace VetClinic.Console
{
    using Autofac;
    using Autofac.Extras.DynamicProxy;
    using System.Configuration;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Commands.Implementations;
    using VetClinic.Console.Interceptors;

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

            builder.RegisterType<StopwatchInterceptor>().AsSelf();

            bool isTest = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

            if (isTest)
            {
                // Interceptor
                builder.RegisterType<UserCommand>()
                    .As<IUserCommand>()
                    .EnableInterfaceInterceptors()
                    //.EnableClassInterceptors()
                    .InterceptedBy(typeof(StopwatchInterceptor));

                // for manual decorator
                //builder.RegisterType<UserCommand>().Named<UserCommand>("createuser");
                // builder.RegisterType<UserCommand>().Named<UserCommand>("createuser")
                //     .WithParameter(
                //     (pi, ctx) => pi.Name == "command",
                //     (pi, ctx) => ctx.ResolveNamed<ICommand>("createuser"));

            }
            else
            {

            }

        }
    }
}
