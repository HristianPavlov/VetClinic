namespace VetClinic.Commands.Implementations
{
    using VetClinic.Commands.Contracts;
    using VetClinic.Providers.Contracts;

    public class Command : ICommand
    {
        private readonly IUserCommand userCommands;
        private readonly IPetCommand animalCommands;
        private readonly IEmployeeCommand employeeCommands;
        private readonly IServiceCommand serviceCommands;
        private readonly IEngineCommand engineCommands;
        private readonly ICashRegisterCommand cashRegisterCommands;
        private readonly IWriter writer;

        public Command(IUserCommand userCommands, IPetCommand animalCommands, IEmployeeCommand employeeCommands, IServiceCommand serviceCommands, IEngineCommand engineCommands, ICashRegisterCommand cashRegisterCommands, IWriter writer)
        {
            this.userCommands = userCommands;
            this.animalCommands = animalCommands;
            this.employeeCommands = employeeCommands;
            this.serviceCommands = serviceCommands;
            this.engineCommands = engineCommands;
            this.cashRegisterCommands = cashRegisterCommands;
            this.writer = writer;
        }
    }
}
