namespace VetClinic
{
    using System;
    using System.Linq;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Repositories;

    public class EngineExample : IEngine
    {
        private readonly IUserRepository usersDb;
        private readonly IUserCommand userCommands;

        public EngineExample(IUserRepository usersDb, IUserCommand commands)
        {
            this.usersDb = usersDb;
            this.userCommands = commands;
        }

        public void Start()
        {
            Console.WriteLine("System running...");
            Console.Write("Search person by phone number. Type phone number here: ");

            var phone = Console.ReadLine();

            var userExists = this.usersDb.Users.Any(u => u.PhoneNumber == phone);

            if (!userExists)
            {
                Console.WriteLine(("User not found! Please proceed to register"));
                Console.WriteLine(("Type registerUser firstname lastname phone email separated by space..."));
            }
            else
            {
                Console.WriteLine("This User exists in database. Please proceed to add your command");
            }

            while (true)
            {
                var command = Console.ReadLine();

                ProcessCommand(command);

                Console.WriteLine("Waiting for command...");
            }
        }

        private void ProcessCommand(string command)
        {
            var commandParts = command.Split(' ').ToList();

            if (commandParts.Count() == 0)
            {
                Console.WriteLine("Please add a command!");      
            }

            switch (commandParts[0]) // all three implemented methods working
            {
                case "registerUser": this.userCommands.CreateUser(commandParts); break;
                case "removeUser": this.userCommands.RemoveUser(commandParts); break;
                case "userPets": this.userCommands.GetUserPets(commandParts); break;
                case "allUsers": this.userCommands.ListAllUsers(); break;
                // case "registerCat": this.commands.CreateCat(commandParts); break;
                // case "registerDog": this.commands.CreateDog(commandParts); break;
                // case "registerHamster": this.commands.CreateHamster(commandParts); break;
                // case "registerAdmin": this.commands.CreateAdmin(commandParts); break;
                // case "registerVeterinarian": this.commands.CreateVeterinarian(commandParts); break;
                // case "help": this.commands.GetUserInfo(commandParts); break;

                default: Console.WriteLine("Invalid command! To read about all commmands, write help and press enter"); break;
            }

            Console.WriteLine($"Command {commandParts[0]} completed successfully. Please wait...");
        }
    }
}
