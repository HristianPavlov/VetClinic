using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.UserCommands
{
    public class SearchUserByPhoneCommand : AbstractCommand, ICommand
    {
        private readonly IUserRepository users;
        private readonly IWriter writer;

        public SearchUserByPhoneCommand(IUserRepository users, IWriter writer)
        {
            this.users = users ?? throw new ArgumentNullException("users");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            SearchUserByPhone();
        }

        private void SearchUserByPhone()
        {
            var parameters = this.Parameters;
            var phone = parameters[1];
            var user = this.users.Users.SingleOrDefault(u => u.PhoneNumber == phone);

            if (user == null)
            {
                this.writer.WriteLine($"User with phone number {phone} was not found! Please proceed to register");
            }
            else
            {
                this.writer.WriteLine($"User {user.FirstName} {user.LastName} was found with searched phone number {phone}");
                this.writer.WriteLine($"{user.FirstName}'s Info:");
                this.writer.WriteLine($"{user.PrintInfo()}");
            }
        }
    }
}

