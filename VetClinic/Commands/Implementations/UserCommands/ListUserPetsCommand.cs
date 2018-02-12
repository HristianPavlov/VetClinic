using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.UserCommands
{
    public class ListUserPetsCommand : AbstractCommand, ICommand
    {
        private readonly IUserRepository users;
        private readonly IWriter writer;

        public ListUserPetsCommand(IUserRepository users, IWriter writer)
        {
            this.users = users ?? throw new ArgumentNullException("users");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            ListUserPets();
        }

        private void ListUserPets()
        {
            var parameters = this.Parameters;

            var userPhone = parameters[1];
            var user = this.users.Users.SingleOrDefault(p => p.PhoneNumber == userPhone);

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }

            this.writer.WriteLine(user.ListUserPets());
        }
    }
}
