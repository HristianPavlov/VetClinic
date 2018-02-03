namespace VetClinic
{
    using Autofac;
    using System.Reflection;

    public class Startup
    {
        static void Main()
        {
            //if (bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"])) { }

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
