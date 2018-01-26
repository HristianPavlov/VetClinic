namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Linq;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common.ConsoleServices.Contracts;

    public class ProcessorCommand : IProcessorCommand
    {
        private readonly IUserCommand userCommands;
        private readonly IPetCommand animalCommands;
        private readonly IEmployeeCommand employeeCommands;
        private readonly IServiceCommand serviceCommands;
        private readonly IEngineCommand engineCommands;
        private readonly ICashRegisterCommand cashRegisterCommands;
        private readonly IWriter writer;

        public ProcessorCommand(IUserCommand userCommands, IPetCommand animalCommands, IEmployeeCommand employeeCommands, IServiceCommand serviceCommands, IEngineCommand engineCommands, ICashRegisterCommand cashRegisterCommands, IWriter writer)
        {
            this.userCommands = userCommands;
            this.animalCommands = animalCommands;
            this.employeeCommands = employeeCommands;
            this.serviceCommands = serviceCommands;
            this.engineCommands = engineCommands;
            this.cashRegisterCommands = cashRegisterCommands;
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
                #region // execute with reflection not working
                //var command = commandParts[0];

                //var commands = this.engineCommands.GetAllCommands();

                //if (commands == null)
                //{
                //    throw new ArgumentNullException("No commands created yet");
                //}

                //foreach (var commandList in commands.Skip(3))
                //{
                //    foreach (var method in commandList)
                //    {
                //        if (method.Name.ToLower() == command.ToLower())
                //        {
                //            // TODO "this" should be replaced with dynamically commnad
                //            method.Invoke(this, new object[] { commandParts });
                //            return;
                //        }
                //    }
                //}
                #endregion

                // execute with switch
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
                        this.cashRegisterCommands.AddBookedService(commandParts); break;

                    // Commands
                    case "listcommands": this.engineCommands.ListCommands(); break;

                    // Accounting
                    case "updatebalance":
                        this.cashRegisterCommands.UpdateBalance(
                        this.serviceCommands.CloseAccount(commandParts)); break;
                    case "printbalance": this.cashRegisterCommands.PrintBalance(); break;
                    case "printbookedservices": this.cashRegisterCommands.PrintBookedServices(); break;

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