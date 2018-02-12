using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.AccountingCommands
{
    public class CloseAccountCommand : AbstractCommand, ICommand
    {
        private readonly IUserRepository users;
        private readonly IAccountingRepository accountingRepository;
        private readonly IWriter writer;

        public CloseAccountCommand(IUserRepository users, IAccountingRepository accountingRepository, IWriter writer)
        {
            this.users = users ?? throw new ArgumentNullException("users");
            this.writer = writer ?? throw new ArgumentNullException("writer");
            this.accountingRepository = accountingRepository ?? throw new ArgumentNullException("accountingRepository");
        }

        public override void Execute()
        {
            var parameters = this.Parameters;
            var userPhone = parameters[1];

            var user = this.users.Users.SingleOrDefault(u => u.PhoneNumber == userPhone);
            if (user == null)
            {
                throw new ArgumentNullException("User was not found");
            }

            decimal amount = user.Bill;
            this.accountingRepository.UpdateBalance(amount);
            user.Bill = 0;

            this.writer.WriteLine($"{user.FirstName} {user.LastName}'s account was closed");
        }
    }
}
