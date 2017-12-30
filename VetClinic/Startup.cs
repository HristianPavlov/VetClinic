namespace VetClinic
{
    using System;
    using VetClinic.Commands.Implementations;
    using VetClinic.Data.Repositories.Implementations;
    using VetClinic.Factories.Implemetations;

    public class Startup
    {
        static void Main()
        {
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

            var cashRegister = new CashRegisterCommand(serviceDb);
            engineCommands.ImportantEventHappened += eventHandler;


            var engine = new Engine(userCommands, animalCommands, employeeCommands, serviceCommands, engineCommands, cashRegister);

            engine.Start();
        }
    }
}
