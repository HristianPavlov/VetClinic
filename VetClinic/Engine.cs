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
                case "deleteUser": this.userCommands.DeleteUser(commandParts); break;
                case "userPets": this.userCommands.ListUserPets(commandParts); break;
                case "searchUserByPhone": this.userCommands.SearchByPhone(commandParts); break;
                case "allUsers": this.userCommands.ListUsers(); break;

                case "registerEmployee": this.employeeCommands.CreateEmployee(commandParts); break;
                case "deleteEmployee": this.employeeCommands.RemoveEmployee(commandParts); break;
                case "allEmployees": this.employeeCommands.ListEmployees(); break;
                case "searchEmployeeByPhone": this.employeeCommands.SearchByPhone(commandParts); break;

                // Hris
                case "registerAnimal": this.animalCommands.CreateAnimal(commandParts); break;
                //deleteAnimal
                //allAnimals
                //searchAnimalByUserPhone
                // case "help": this.commands.GetUserInfo(commandParts); break;

                //customExceptionClass
                //struct     

                // Jivka
                case "showServices": this.userCommands.ShowServices(); break;
                case "selectService": this.userCommands.SelectService(commandParts[1]); break;


                default: Console.WriteLine("Invalid command! To read about all commmands, write help and press enter"); break;
            }

            Console.WriteLine($"Command {commandParts[0]} completed successfully.");
        }
    }
}
