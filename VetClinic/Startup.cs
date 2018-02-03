namespace VetClinic
{
    using Autofac;
    using System.Reflection;

    public class Startup
    {
        static void Main()
        {
            var builder = new ContainerBuilder();

            //if (bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"])) { }

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
