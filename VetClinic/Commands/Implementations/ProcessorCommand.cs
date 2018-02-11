namespace VetClinic.Commands.Implementations
{
    using Autofac;
    using System;
    using System.Reflection;
    using VetClinic.Commands.Contracts;
    using VetClinic.Core.Commands.Contracts;
    using VetClinic.Factories.Contracts;
    using VetClinic.Providers.Contracts;

    public class ProcessorCommand : IProcessorCommand
    {
        private readonly IUserCommand userCommands;
        private readonly IPetCommand petCommands;
        private readonly IEmployeeCommand employeeCommands;
        private readonly IServiceCommand serviceCommands;
        private readonly ICommand commands;
        private readonly ICashRegisterCommand cashRegisterCommands;
        private readonly IWriter writer;
        private readonly ICommandFactory commandFactory;
        private readonly ICommandParser commandParser;
        private readonly IComponentContext context;

        public ProcessorCommand(IUserCommand userCommands, IPetCommand petCommands, IEmployeeCommand employeeCommands, IServiceCommand serviceCommands, ICommand commands, ICashRegisterCommand cashRegisterCommands, IWriter writer, ICommandFactory commandFactory, ICommandParser commandParser, IComponentContext context)
        {
            this.userCommands = userCommands;
            this.petCommands = petCommands;
            this.employeeCommands = employeeCommands;
            this.serviceCommands = serviceCommands;
            this.commands = commands;
            this.cashRegisterCommands = cashRegisterCommands;
            this.writer = writer;
            this.commandFactory = commandFactory;
            this.commandParser = commandParser;
            this.context = context;
        }

        public void ProcessCommand(string commandAsString)
        {
            var commandParts = this.commandParser.ParseParameters(commandAsString);

            try
            {
                #region // execute with reflection not working
                var allCommands = this.commandFactory.GetAllCommands();

                object commandClass = null;
                MethodInfo commandMethod = null;

                foreach (var currrentCommand in allCommands)
                {
                    foreach (var currentMethod in currrentCommand.GetMethods())
                    {
                        if (currentMethod.Name.ToLower() == commandAsString)
                        {
                            commandMethod = currentMethod;
                            commandClass = currrentCommand;
                            break;
                        }
                    }
                }

                //var commandClassToCall = this.commandFactory.ResolveCommand(commandAsString);
                //var commandClassToCall = this.context.ResolveNamed<commandClass.GetType>(commandAsString);
                //commandMethod.Invoke(this.userCommands, new object[] { commandParts });
                #endregion

                // execute with switch
                switch (commandParts[0])
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
                        this.petCommands.CreatePet(commandParts);
                        this.userCommands.CreatePet(commandParts); break;
                    case "deletepet":
                        this.petCommands.DeletePet(commandParts);
                        this.userCommands.CreatePet(commandParts); break;
                    case "listpets": this.petCommands.ListPets(); break;

                    // Services
                    case "createservice": this.serviceCommands.CreateService(commandParts); break;
                    case "deleteservice": this.serviceCommands.DeleteService(commandParts); break;
                    case "listservices": this.serviceCommands.ListServices(commandParts); break;
                    case "performservice":
                        this.serviceCommands.PerformService(commandParts);
                        this.cashRegisterCommands.AddBookedService(commandParts); break;

                    // Commands
                    case "listcommands": this.commands.ListCommands(); break;

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