using Autofac;
using System.Reflection;

namespace VetClinic.Console
{
    public class Startup
    {
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Run();
        }
    }
}
