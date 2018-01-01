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
        private readonly ICommand commands;
        private readonly IWriter writer;

        public ProcessorCommand(IUserCommand userCommands, IPetCommand animalCommands, IEmployeeCommand employeeCommands, IServiceCommand serviceCommands, IEngineCommand engineCommands, ICashRegisterCommand cashRegister, ICommand commands, IWriter writer)
        {
            this.userCommands = userCommands;
            this.animalCommands = animalCommands;
            this.employeeCommands = employeeCommands;
            this.serviceCommands = serviceCommands;
            this.engineCommands = engineCommands;
            this.cashRegister = cashRegister;
            this.commands = commands;
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
                //var commandsList = this.commands.GetAllCommands();
                //var command = commandParts[0];
                //var commandFound = commandsList.FirstOrDefault(c => c == command);
                //if (commandFound != null)
                //{
                //    //find and execute dinamically
                //}

                switch (commandParts[0].ToLower())
                {
                    // User
                    case "createuser": this.userCommands.CreateUser(commandParts); break;
                    case "deleteuser": this.userCommands.DeleteUser(commandParts); break;
                    case "listuserpets": this.userCommands.ListUserPets(commandParts); break;
                    case "searchuserbyphone": this.userCommands.SearchUserByPhone(commandParts); break;
                    case "listusers": this.userCommands.ListUsers(); break;

                    // Employee
                    case "createemployee": this.employeeCommands.CreateEmployee(commandParts); break;
                    case "deleteemployee": this.employeeCommands.DeleteEmployee(commandParts); break;
                    case "listemployees": this.employeeCommands.ListEmployees(); break;
                    case "searchemployeebyphone": this.employeeCommands.SearchEmployeeByPhone(commandParts); break;

                    // Pet
                    case "createpet":
                        this.animalCommands.CreatePet(commandParts);
                        this.userCommands.CreatePet(commandParts); break;
                    case "deletepet":
                        this.animalCommands.DeletePet(commandParts);
                        this.userCommands.CreatePet(commandParts); break;
                    case "listpets": this.animalCommands.ListPets(); break;

                    // Services
                    case "createservice": this.serviceCommands.CreateService(commandParts); break;
                    case "deleteservice": this.serviceCommands.DeleteService(commandParts); break;
                    case "listservices": this.serviceCommands.ListServices(commandParts); break;
                    case "performservice":
                        this.serviceCommands.PerformService(commandParts);
                        this.cashRegister.AddBookedService(commandParts); break;

                    // Commands
                    case "createcommand": this.engineCommands.CreateCommand(commandParts); break;
                    case "deletecommand": this.engineCommands.DeleteCommand(commandParts); break;
                    case "listcommands": this.engineCommands.ListCommands(); break;

                    // Accounting
                    case "updatebalance":
                        this.cashRegister.UpdateBalance(
                        this.serviceCommands.CloseAccount(commandParts)); break;
                    case "printbalance": this.cashRegister.PrintBalance(); break;
                    case "printbookedservices": this.cashRegister.PrintBookedServices(); break;

                    default: this.writer.WriteLine("Invalid command! To read about all commmands, write listCommands and press enter"); break;
                }
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(ex.Message);
            }
        }
    }
}
