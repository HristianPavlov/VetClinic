using System;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.UserCommands
{
    public class CreateUserCommand : AbstractCommand, ICommand
    {
        private readonly IPersonFactory personFactory;
        private readonly IUserRepository users;
        private readonly IWriter writer;

        public CreateUserCommand(IPersonFactory personFactory, IUserRepository users, IWriter writer)
        {
            this.personFactory = personFactory ?? throw new ArgumentNullException("personFactory");
            this.users = users ?? throw new ArgumentNullException("users");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            CreateUser();
        }

        private void CreateUser()
        {
            var parameters = this.Parameters;

            var firstName = parameters[1];
            var lastName = parameters[2];
            var phoneNumber = parameters[3];
            var email = parameters[4];

            var newUser = this.personFactory.CreateUser(firstName, lastName, phoneNumber, email);

            this.users.CreateUser(newUser);
            this.writer.WriteLine($"User {firstName} {lastName} successfully created");
        }
    }
}
