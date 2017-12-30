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
        private readonly IServiceCommand serviceCommands;
        private readonly IEngineCommand engineCommands;
        private readonly ICashRegisterCommand cashRegister;

        public Engine(IUserCommand userCommands, IAnimalCommand animalCommands, IEmployeeCommand employeeCommands, IServiceCommand serviceCommands, IEngineCommand engineCommands, ICashRegisterCommand cashRegister)
        {
            this.userCommands = userCommands;
            this.animalCommands = animalCommands;
            this.employeeCommands = employeeCommands;
            this.serviceCommands = serviceCommands;
            this.engineCommands = engineCommands;
            this.cashRegister = cashRegister;
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
                // User
                case "registerUser": this.userCommands.CreateUser(commandParts); break;
                case "deleteUser": this.userCommands.DeleteUser(commandParts); break;
                case "listUserPets": this.userCommands.ListUserPets(commandParts); break;
                case "searchUserByPhone": this.userCommands.SearchUserByPhone(commandParts); break;
                case "allUsers": this.userCommands.ListUsers(); break;

                // Employee
                case "registerEmployee": this.employeeCommands.CreateEmployee(commandParts); break;
                case "deleteEmployee": this.employeeCommands.DeleteEmployee(commandParts); break;
                case "listEmployees": this.employeeCommands.ListEmployees(); break;
                case "searchEmployeeByPhone": this.employeeCommands.SearchEmployeeByPhone(commandParts); break;

                // Animal
                case "registerAnimal": this.animalCommands.CreateAnimal(commandParts); break;
                case "deleteAnimal": this.animalCommands.DeleteAnimal(commandParts); break;
                case "listAnimals": this.animalCommands.ListPets(); break;

                // Services
                case "createService": this.serviceCommands.CreateService(commandParts); break;
                case "deleteService": this.serviceCommands.DeleteService(commandParts); break;
                case "listServices": this.serviceCommands.ListServices(commandParts); break;

                // Commands
                case "createCommand": this.engineCommands.CreateCommand(commandParts); break;
                case "deleteCommand": this.engineCommands.DeleteCommand(commandParts); break;
                case "help": this.engineCommands.Help(); break;

                // Accounting
                case "addBookedService": this.cashRegister.AddBookedService(commandParts); break;
                case "updateBalance": this.cashRegister.UpdateBalance(commandParts); break;
                case "printBalance": this.cashRegister.PrintBalance(); break;

                default: Console.WriteLine("Invalid command! To read about all commmands, write help and press enter"); break;
            }

            Console.WriteLine($"Command {commandParts[0]} completed successfully.");
        }
    }
}
