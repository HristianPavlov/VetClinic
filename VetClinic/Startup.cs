namespace VetClinic
{
    using Autofac;
    using System;
    using VetClinic.Commands.Implementations;
    using VetClinic.Common.ConsoleServices.Implementations;
    using VetClinic.Data.Repositories.Implementations;
    using VetClinic.Factories.Implemetations;

    public class Startup
    {
        static void Main()
        {
            // autofac
            //var container = AutofacContainer.Build();

            //var petDb = container.Resolve<PetRepository>();
            //var userCommands = container.Resolve<UserCommand>();
            //var petCommands = container.Resolve<PetCommand>();
            //var employeeCommands = container.Resolve<EmployeeCommand>();
            //var serviceCommands = container.Resolve<ServiceCommand>();
            //var engineCommands = container.Resolve<EngineCommand>();
            //var cashRegisterCommands = container.Resolve<CashRegisterCommand>();
            //var engine = container.Resolve<Engine>();

            //var eventHandler = new EventHandler((command, message) => { Console.WriteLine(message); });
            //userCommands.ImportantEventHappened += eventHandler;
            //petCommands.ImportantEventHappened += eventHandler;
            //employeeCommands.ImportantEventHappened += eventHandler;
            //serviceCommands.ImportantEventHappened += eventHandler;
            //engineCommands.ImportantEventHappened += eventHandler;
            //cashRegisterCommands.ImportantEventHappened += eventHandler;


            var personFactory = new PersonFactory();
            var animalFactory = new PetFactory();
            var serviceFactory = new ServiceFactory();
            var commandFactory = new CommandFactory();

            var userDb = new UserRepository();
            var employeeDb = new EmployeeRepository();
            var animalDb = new PetRepository(userDb);
            var serviceDb = new ServiceRepository();
            var commandDb = new CommandRepository();

            var writer = new ConsoleWriter();

            var eventHandler = new EventHandler((command, message)
                => { writer.WriteLine(message); });

            var userCommands = new UserCommand(personFactory, userDb, animalDb, writer);
            userCommands.ImportantEventHappened += eventHandler;

            var animalCommands = new PetCommand(animalFactory, animalDb, writer);
            animalCommands.ImportantEventHappened += eventHandler;

            var employeeCommands = new EmployeeCommand(personFactory, employeeDb, writer);
            employeeCommands.ImportantEventHappened += eventHandler;

            var serviceCommands = new ServiceCommand(serviceFactory, serviceDb, userDb, writer);
            serviceCommands.ImportantEventHappened += eventHandler;

            var engineCommands = new EngineCommand(commandFactory, commandDb, writer);
            engineCommands.ImportantEventHappened += eventHandler;

            var cashRegisterCommands = new CashRegisterCommand(serviceDb, writer);
            cashRegisterCommands.ImportantEventHappened += eventHandler;

            var processorCommand = new ProcessorCommand(userCommands, animalCommands, employeeCommands, serviceCommands, engineCommands, cashRegisterCommands, writer);

            var engine = new Engine(writer, processorCommand);

            engine.Start();
        }
    }
}
