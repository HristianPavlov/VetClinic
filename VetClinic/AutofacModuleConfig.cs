namespace VetClinic
{
    using Autofac;
    using System.Reflection;
    using VetClinic.Data.Repositories.Contracts;

    public class AutofacModuleConfig : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            // VetClinic
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IEngine)))
                .AsImplementedInterfaces()
                .SingleInstance();

            // VetClinic.Data
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ICommandRepository)))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ContainerBuilder>().AsSelf().SingleInstance();
        }
    }
}
