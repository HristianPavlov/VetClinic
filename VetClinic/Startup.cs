namespace VetClinic
{
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

            var userCommands = new UserCommand(personFactory, userDb);
            var animalCommands = new AnimalCommand(animalFactory, animalDb);
            var employeeCommands = new EmployeeCommand(personFactory, employeeDb);

            var engine = new Engine(userCommands, animalCommands, employeeCommands);

            engine.Start();
        }
    }
}
