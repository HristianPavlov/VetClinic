namespace VetClinic.Console
{
    using Autofac;
    using System.Reflection;
    using VetClinic.Data.Repositories.Contracts;

    public class AutofacModuleConfig : Autofac.Module
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

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ICommandRepository)))
                .Where(x => x.Namespace.Contains("Repositories"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ContainerBuilder>().AsSelf().SingleInstance();
        }
    }
}
