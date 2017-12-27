namespace VetClinic
{
    using System;
    using VetClinic.Commands.Implementations;
    using VetClinic.Data.Repositories;
    using VetClinic.Factories.Implemetations;

    public class Startup
    {
        static void Main()
        {
            var personFactory = new PersonFactory();
            var animalFactory = new AnimalFactory();

            var userDb = new UserRepository();
            var employeeDb = new EmployeeRepository();
            var animalDb = new AnimalRepository(userDb);


            var eventHandler = new EventHandler((command, message) => { Console.WriteLine(message); });

            var userCommands = new UserCommand(personFactory, userDb);
            userCommands.SomethingHappened += eventHandler;

            var animalCommands = new AnimalCommand(animalFactory, animalDb);
            animalCommands.SomethingHappened += eventHandler;

            var employeeCommands = new EmployeeCommand(personFactory, employeeDb);
            employeeCommands.SomethingHappened += eventHandler;


            var engine = new Engine(userCommands, animalCommands, employeeCommands);

            engine.Start();
        }
    }
}
