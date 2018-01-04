namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common.ConsoleServices.Contracts;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public class UserCommand : IUserCommand
    {
        private readonly IPersonFactory personFactory;
        private readonly IUserRepository users;
        private readonly IPetRepository pets;
        private readonly IWriter writer;

        public UserCommand(IPersonFactory personFactory, IUserRepository users, IPetRepository pets, IWriter writer)
        {
            this.personFactory = personFactory;
            this.users = users;
            this.pets = pets;
            this.writer = writer;
        }

        public void CreatePet(IList<string> parameters)
        {
            var userPhone = parameters[1];
            // var animalType = parameters[2]; // not used input parameter
            var petName = parameters[3];

            var user = this.users.Users.FirstOrDefault(u => u.PhoneNumber == userPhone);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var pet = this.pets.Pets.FirstOrDefault(a => a.Name == petName);

            if (pet == null)
            {
                throw new ArgumentException("Pet not found");
            }

            user.AddPet(pet);
        }

        public void DeletePet(IList<string> parameters)
        {
            var userPhone = parameters[1];
            // var animalType = parameters[2];  // not used input parameter
            var animalName = parameters[3];

            var user = this.users.Users.FirstOrDefault(u => u.PhoneNumber == userPhone);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var pet = this.pets.Pets.FirstOrDefault(a => a.Name == animalName);

            if (pet == null)
            {
                throw new ArgumentException("Pet not found");
            }

            user.RemovePet(pet);
        }

        public void CreateUser(IList<string> parameters)
        {
            var firstName = parameters[1];
            var lastName = parameters[2];
            var phoneNumber = parameters[3];
            var email = parameters[4];

            var newUser = this.personFactory.CreateUser(firstName, lastName, phoneNumber, email);

            this.users.CreateUser(newUser);
            this.writer.WriteLine($"User {firstName} {lastName} successfully created");
        }

        public void DeleteUser(IList<string> parameters)
        {
            var userId = parameters[1];

            var user = this.users.Users.FirstOrDefault(p => p.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            this.users.DeleteUser(userId);
            this.writer.WriteLine($"User {user.FirstName} {user.LastName} successfully removed from database");
        }

        public void ListUserPets(IList<string> parameters)
        {
            var userPhone = parameters[1];

            var user = this.users.Users.FirstOrDefault(p => p.PhoneNumber == userPhone);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            this.writer.WriteLine(user.ListUserPets());
        }

        public void ListUsers()
        {
            if (this.users.Users.Count == 0)
            {
                throw new ArgumentException("No users registered");
            }

            var sb = new StringBuilder();

            sb.AppendLine("All users:");

            foreach (var user in this.users.Users)
            {
                sb.AppendLine(user.PrintInfo());
            }

            this.writer.WriteLine(sb.ToString());
        }

        public void SearchUserByPhone(IList<string> parameters)
        {
            var phone = parameters[1];

            var user = this.users.Users.FirstOrDefault(u => u.PhoneNumber == phone);

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
