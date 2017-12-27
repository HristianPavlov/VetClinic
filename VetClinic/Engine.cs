namespace VetClinic
{
    using System;
    using System.Linq;
    using VetClinic.Commands.Contracts;

    public class Engine : IEngine
    {
        private readonly IUserCommand userCommands;
        private readonly IAnimalCommand animalCommands;
        private readonly IEmployeeCommand employeeCommands;

        public Engine(IUserCommand commands, IAnimalCommand animalCommands, IEmployeeCommand employeeCommands)
        {
            this.userCommands = commands;
            this.animalCommands = animalCommands;
            this.employeeCommands = employeeCommands;
        }

        public void Start()
        {
            Console.WriteLine("System running...");
          
            while (true)
            {
                var command = Console.ReadLine();

                ProcessCommand(command);

                Console.WriteLine("Waiting for command...");
            }
        }

        private void ProcessCommand(string command)
        {
            var commandParts = command.Split(new[] { ' ', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (commandParts.Count() == 0)
            {
                Console.WriteLine("Please add a valid command!");
                return;
            }

            switch (commandParts[0])
            {
                case "registerUser": this.userCommands.CreateUser(commandParts); break;
                case "removeUser": this.userCommands.RemoveUser(commandParts); break;
                case "userPets": this.userCommands.GetUserPets(commandParts); break;
                case "allUsers": this.userCommands.ListAllUsers(); break;
                case "registerEmployee": this.employeeCommands.CreateEmployee(commandParts); break;
                case "removeEmployee": this.employeeCommands.RemoveEmployee(commandParts); break;
                case "allEmployees": this.employeeCommands.ListEmployees(); break;
                case "searchByPhone": this.employeeCommands.FindByPhone(commandParts); break;

                // Hris
                case "createAnimal": this.animalCommands.CreateAnimal(commandParts); break;
                //removeAnimal
                //listAllAnimal
                //customExceptionClass
                //struct     

                // case "help": this.commands.GetUserInfo(commandParts); break;

                default: Console.WriteLine("Invalid command! To read about all commmands, write help and press enter"); break;
            }

            Console.WriteLine($"Command {commandParts[0]} completed successfully. Please wait...");
        }
    }
}
