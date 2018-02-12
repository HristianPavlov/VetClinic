using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.UserCommands
{
    public class DeleteUserCommand : AbstractCommand, ICommand
    {
        private readonly IUserRepository users;
        private readonly IWriter writer;

        public DeleteUserCommand(IUserRepository users, IWriter writer)
        {
            this.users = users ?? throw new ArgumentNullException("users");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            DeleteUser();
        }

        private void DeleteUser()
        {
            var parameters = this.Parameters;

            var userId = parameters[1];
            var user = this.users.Users.SingleOrDefault(p => p.Id == userId);

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }

            this.users.DeleteUser(userId);
            this.writer.WriteLine($"User {user.FirstName} {user.LastName} successfully removed from database");
        }
    }
}
