using Autofac;
using System.Reflection;
using VetClinic.Data.Repositories.Contracts;

namespace VetClinic.Console
{
    public class VetClinicDataConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ICommandRepository)))
               .Where(x => x.Namespace.Contains("Repositories"))
               .AsImplementedInterfaces()
               .SingleInstance();
        }
    }
}