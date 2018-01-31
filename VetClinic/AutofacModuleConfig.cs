namespace VetClinic
{
    using Autofac;
    using System.Reflection;
    using VetClinic.Data.Repositories.Contracts;

    public class AutofacModuleConfig : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ICommandRepository)))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ContainerBuilder>().AsSelf().SingleInstance();
        }
    }
}
