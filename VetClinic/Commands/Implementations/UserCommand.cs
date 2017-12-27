namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Repositories;
    using VetClinic.Factories.Contracts;


    public class UserCommand : IUserCommand
    {
        private readonly IPersonFactory personFactory;
        private readonly IUserRepository userDb;

        public UserCommand(IPersonFactory personFactory, IUserRepository userDb)
        {
            this.personFactory = personFactory;
            this.userDb = userDb;
        }

        public void CreateUser(IList<string> parameters)
        {
            var firstName = parameters[1];
            var lastName = parameters[2];
            var phoneNumber = parameters[3];
            var email = parameters[4];

            var newUser = this.personFactory.CreateUser(firstName, lastName, phoneNumber, email);

            this.userDb.CreateUser(newUser);
            Console.WriteLine($"User {firstName} {lastName} successfully created");
        }

        public void DeleteUser(IList<string> parameters)
        {
            var userId = parameters[1];

            var user = this.userDb.Users.FirstOrDefault(p => p.Id == userId);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            this.userDb.DeleteUser(userId);
            Console.WriteLine($"User {user.FirstName} {user.LastName} successfully removed from database");
        }

        public void ListUserPets(IList<string> parameters)
        {
            var userPhone = parameters[1];

            var user = this.userDb.Users.FirstOrDefault(p => p.PhoneNumber == userPhone);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            Console.WriteLine(user.ListUserPets());
        }

        public void ListUsers()
        {
            if (this.userDb.Users.Count == 0)
            {
                Console.WriteLine("No users registered");
                return;
            }

            var sb = new StringBuilder();

            sb.AppendLine("All users:");

            foreach (var user in this.userDb.Users)
            {
                sb.AppendLine(user.PrintInfo());
            }

            Console.WriteLine(sb.ToString());
        }

        public void SearchByPhone(IList<string> parameters)
        {
            var phone = parameters[1];

            var user = this.userDb.Users.FirstOrDefault(u => u.PhoneNumber == phone);

            if (user == null)
            {
                Console.WriteLine($"User with phone number {phone} was not found! Please proceed to register");
            }
            else
            {
                Console.WriteLine($"User {user.FirstName} {user.LastName} was found with searched phone number {phone}");
                Console.WriteLine($"{user.FirstName}'s Info:");
                Console.WriteLine($"{user.PrintInfo()}");
            }
        }
    }
}
