namespace VetClinic
{
    using Autofac;
    using System.Reflection;
    using VetClinic.Data.Repositories.Contracts;

    public class AutofacContainer : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
                //.Where(x => x.Namespace.Contains("Factories"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ICommandRepository)))
                //.Where(x => x.Namespace.Contains("Repositories"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ContainerBuilder>().AsSelf().SingleInstance();
        }
    }
}
