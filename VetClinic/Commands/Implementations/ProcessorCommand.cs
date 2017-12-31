using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Common.ConsoleServices.Contracts;

namespace VetClinic.Commands.Implementations
{
    public class ProcessorCommand : IProcessorCommand
    {
        private readonly IUserCommand userCommands;
        private readonly IPetCommand animalCommands;
        private readonly IEmployeeCommand employeeCommands;
        private readonly IServiceCommand serviceCommands;
        private readonly IEngineCommand engineCommands;
        private readonly ICashRegisterCommand cashRegister;
        private readonly IWriter writer;

        public ProcessorCommand(IUserCommand userCommands, IPetCommand animalCommands, IEmployeeCommand employeeCommands, IServiceCommand serviceCommands, IEngineCommand engineCommands, ICashRegisterCommand cashRegister, IWriter writer)
        {
            this.userCommands = userCommands;
            this.animalCommands = animalCommands;
            this.employeeCommands = employeeCommands;
            this.serviceCommands = serviceCommands;
            this.engineCommands = engineCommands;
            this.cashRegister = cashRegister;
            this.writer = writer;
        }

        public void ProcessCommand(string commandLine)
        {
            var commandParts = commandLine.Split(new[] { ' ', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (commandParts.Count() == 0)
            {
                this.writer.WriteLine("Please add a valid command!");
                return;
            }
            try
            {
                switch (commandParts[0])
                {
                    // User
                    case "createUser": this.userCommands.CreateUser(commandParts); break;
                    case "deleteUser": this.userCommands.DeleteUser(commandParts); break;
                    case "listUserPets": this.userCommands.ListUserPets(commandParts); break;
                    case "searchUserByPhone": this.userCommands.SearchUserByPhone(commandParts); break;
                    case "listUsers": this.userCommands.ListUsers(); break;

                    // Employee
                    case "createEmployee": this.employeeCommands.CreateEmployee(commandParts); break;
                    case "deleteEmployee": this.employeeCommands.DeleteEmployee(commandParts); break;
                    case "listEmployees": this.employeeCommands.ListEmployees(); break;
                    case "searchEmployeeByPhone": this.employeeCommands.SearchEmployeeByPhone(commandParts); break;

                    // Pet
                    case "createPet":
                        this.animalCommands.CreatePet(commandParts);
                        this.userCommands.CreatePet(commandParts); break;
                    case "deletePet":
                        this.animalCommands.DeletePet(commandParts);
                        this.userCommands.CreatePet(commandParts); break;
                    case "listPets": this.animalCommands.ListPets(); break;

                    // Services
                    case "createService": this.serviceCommands.CreateService(commandParts); break;
                    case "deleteService": this.serviceCommands.DeleteService(commandParts); break;
                    case "listServices": this.serviceCommands.ListServices(commandParts); break;
                    case "performService":
                        this.serviceCommands.PerformService(commandParts);
                        this.cashRegister.AddBookedService(commandParts); break;

                    // Commands
                    case "createCommand": this.engineCommands.CreateCommand(commandParts); break;
                    case "deleteCommand": this.engineCommands.DeleteCommand(commandParts); break;
                    case "help": this.engineCommands.Help(); break;

                    // Accounting
                    case "updateBalance":
                        this.cashRegister.UpdateBalance(
                        this.serviceCommands.closeAccount(commandParts)); break;
                    case "printBalance": this.cashRegister.PrintBalance(); break;
                    case "printBookedServices": this.cashRegister.PrintBookedServices(); break;

                    default: this.writer.WriteLine("Invalid command! To read about all commmands, write help and press enter"); break;
                }
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(ex.Message);
            }
        }
    }
}
