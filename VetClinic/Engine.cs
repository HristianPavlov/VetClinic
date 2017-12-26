namespace VetClinic
{
    using System;
    using System.Linq;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Repositories;

    public class Engine : IEngine
    {
        private readonly IUserRepository usersDb;
        private readonly IUserCommand userCommands;
        private readonly IAnimalCommand animalCommands;

        public Engine(IUserRepository usersDb, IUserCommand commands, IAnimalCommand animalCommands)
        {
            this.usersDb = usersDb;
            this.userCommands = commands;
            this.animalCommands = animalCommands;
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
            var commandParts = command.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).ToList();

            if (commandParts.Count() == 0)
            {
                Console.WriteLine("Please add a command!");
                return;
            }

            switch (commandParts[0]) // all three implemented methods working
            {
                case "registerUser": this.userCommands.CreateUser(commandParts); break;
                case "removeUser": this.userCommands.RemoveUser(commandParts); break;
                case "userPets": this.userCommands.GetUserPets(commandParts); break;
                case "allUsers": this.userCommands.ListAllUsers(); break;
                case "createAnimal": this.animalCommands.CreateAnimal(commandParts); break;

                    //Hris
              //removeAnimal
              //
              //listAllAnimal
              //customExceptionClass
              //struct

                //Marto
                // case "registerAdmin": this.commands.CreateAdmin(commandParts); break;
                // case "registerVeterinarian": this.commands.CreateVeterinarian(commandParts); break;
                //Staff CRUD+Search by ID
                //lsitThem

                

                // case "help": this.commands.GetUserInfo(commandParts); break;

                default: Console.WriteLine("Invalid command! To read about all commmands, write help and press enter"); break;
            }

            Console.WriteLine($"Command {commandParts[0]} completed successfully. Please wait...");
        }
    }
}
