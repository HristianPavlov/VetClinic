using System;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.AccountingCommands
{
    public class PrintBalanceCommand : AbstractCommand, ICommand
    {
        private readonly IWriter writer;
        private readonly IAccountingRepository accountingRepository;

        public PrintBalanceCommand(IWriter writer, IAccountingRepository accountingRepository)
        {
            this.writer = writer ?? throw new ArgumentNullException("writer");
            this.accountingRepository = accountingRepository ?? throw new ArgumentNullException("accountingRepository");
        }

        public override void Execute()
        {
            var balance = this.accountingRepository.Balance;
            this.writer.WriteLine($"{balance:F2} $");
        }
    }
}
