namespace VetClinic
{
    using Autofac;
    using VetClinic.Commands.Implementations;
    using VetClinic.Data.Repositories.Implementations;

    public class Startup
    {
        static void Main()
        {
            var container = AutofacContainer.Build();

            var petDb = container.Resolve<PetRepository>();
            var userCommands = container.Resolve<UserCommand>();
            var petCommands = container.Resolve<PetCommand>();
            var employeeCommands = container.Resolve<EmployeeCommand>();
            var serviceCommands = container.Resolve<ServiceCommand>();
            var engineCommands = container.Resolve<EngineCommand>();
            var cashRegisterCommands = container.Resolve<CashRegisterCommand>();
            var processorCommand = container.Resolve<ProcessorCommand>();

            var engine = container.Resolve<Engine>();
            engine.Start();
        }
    }
}
