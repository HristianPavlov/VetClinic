namespace VetClinic
{
    using Autofac;
    using System;
    using VetClinic.Commands.Implementations;
    using VetClinic.Data.Repositories.Implementations;
    using VetClinic.Factories.Implemetations;

    public class Startup
    {
        static void Main()
        {
            // autofac
            //var container = AutofacContainer.Build();
            //var animalDb = container.Resolve<AnimalRepository>();
            //var userCommands = container.Resolve<UserCommand>();
            //var animalCommands = container.Resolve<AnimalCommand>();
            //var employeeCommands = container.Resolve<EmployeeCommand>();
            //var serviceCommands = container.Resolve<ServiceCommand>();
            //var engineCommands = container.Resolve<EngineCommand>();
            //var cashRegisterCommands = container.Resolve<CashRegisterCommand>();
            //var engine = container.Resolve<Engine>();

            //var eventHandler = new EventHandler((command, message) => { Console.WriteLine(message); });
            //userCommands.ImportantEventHappened += eventHandler;
            //animalCommands.ImportantEventHappened += eventHandler;
            //employeeCommands.ImportantEventHappened += eventHandler;
            //serviceCommands.ImportantEventHappened += eventHandler;
            //engineCommands.ImportantEventHappened += eventHandler;
            //cashRegisterCommands.ImportantEventHappened += eventHandler;


            var personFactory = new PersonFactory();
            var animalFactory = new AnimalFactory();
            var serviceFactory = new ServiceFactory();
            var commandFactory = new CommandFactory();

            var userDb = new UserRepository();
            var employeeDb = new EmployeeRepository();
            var animalDb = new AnimalRepository(userDb);
            var serviceDb = new ServiceRepository();
            var commandDb = new CommandRepository();

            var eventHandler = new EventHandler((command, message) => { Console.WriteLine(message); });

            var userCommands = new UserCommand(personFactory, userDb);
            userCommands.ImportantEventHappened += eventHandler;

            var animalCommands = new AnimalCommand(animalFactory, animalDb);
            animalCommands.ImportantEventHappened += eventHandler;

            var employeeCommands = new EmployeeCommand(personFactory, employeeDb);
            employeeCommands.ImportantEventHappened += eventHandler;

            var serviceCommands = new ServiceCommand(serviceFactory, serviceDb, userDb);
            serviceCommands.ImportantEventHappened += eventHandler;

            var engineCommands = new EngineCommand(commandFactory, commandDb);
            engineCommands.ImportantEventHappened += eventHandler;

            var cashRegisterCommands = new CashRegisterCommand(serviceDb);
            cashRegisterCommands.ImportantEventHappened += eventHandler;


            var engine = new Engine(userCommands, animalCommands, employeeCommands, serviceCommands, engineCommands, cashRegisterCommands);

            engine.Start();
        }
    }
}
