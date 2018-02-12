using System;
using System.Text;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.UserCommands
{
    public class ListUsersCommand : AbstractCommand, ICommand
    {
        private readonly IUserRepository users;
        private readonly IWriter writer;

        public ListUsersCommand(IUserRepository users, IWriter writer)
        {
            this.users = users ?? throw new ArgumentNullException("users");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            if (this.users.Users.Count == 0)
            {
                throw new ArgumentNullException("No users registered");
            }

            var sb = new StringBuilder();

            sb.AppendLine("All users:");

            foreach (var user in this.users.Users)
            {
                sb.AppendLine(user.PrintInfo());
            }

            this.writer.WriteLine(sb.ToString());
        }
    }
}
