namespace VetClinic
{
    using Autofac;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Repositories.Contracts;

    public class Startup
    {
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = AutofacContainer.Build();

            //var petDb = container.Resolve<IPetRepository>();
            //var userCommands = container.Resolve<IUserCommand>();
            //var petCommands = container.Resolve<IPetCommand>();
            //var employeeCommands = container.Resolve<IEmployeeCommand>();
            //var serviceCommands = container.Resolve<IServiceCommand>();
            //var engineCommands = container.Resolve<IEngineCommand>();
            //var cashRegisterCommands = container.Resolve<ICashRegisterCommand>();
            //var processorCommand = container.Resolve<IProcessorCommand>();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}
