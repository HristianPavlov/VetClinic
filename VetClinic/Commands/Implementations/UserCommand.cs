namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public class UserCommand : VetClinicEventHandler, IUserCommand
    {
        private readonly IPersonFactory personFactory;
        private readonly IUserRepository userDb;
        private readonly IPetRepository animalDb;

        public UserCommand(IPersonFactory personFactory, IUserRepository userDb, IPetRepository animalDb)
        {
            this.personFactory = personFactory;
            this.userDb = userDb;
            this.animalDb = animalDb;
        }

        public void CreatePet(IList<string> parameters)
        {
            var userPhone = parameters[1];
            // var animalType = parameters[2];
            var animalName = parameters[3];

            var user = this.userDb.Users.FirstOrDefault(u => u.PhoneNumber == userPhone);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var pet = this.animalDb.Pets.FirstOrDefault(a => a.Name == animalName);

            if (pet == null)
            {
                throw new ArgumentException("Pet not found");
            }

            user.AddPet(pet);
        }

        public void DeletePet(IList<string> parameters)
        {
            var userPhone = parameters[1];
            // var animalType = parameters[2];
            var animalName = parameters[3];

            var user = this.userDb.Users.FirstOrDefault(u => u.PhoneNumber == userPhone);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var pet = this.animalDb.Pets.FirstOrDefault(a => a.Name == animalName);

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

            this.userDb.CreateUser(newUser);
            this.OnMessage($"User {firstName} {lastName} successfully created");
        }

        public void DeleteUser(IList<string> parameters)
        {
            var userId = parameters[1];

            var user = this.userDb.Users.FirstOrDefault(p => p.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            this.userDb.DeleteUser(userId);
            this.OnMessage($"User {user.FirstName} {user.LastName} successfully removed from database");
        }

        public void ListUserPets(IList<string> parameters)
        {
            var userPhone = parameters[1];

            var user = this.userDb.Users.FirstOrDefault(p => p.PhoneNumber == userPhone);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            Console.WriteLine(user.ListUserPets());
        }

        public void ListUsers()
        {
            if (this.userDb.Users.Count == 0)
            {
                throw new ArgumentException("No users registered");
            }

            var sb = new StringBuilder();

            sb.AppendLine("All users:");

            foreach (var user in this.userDb.Users)
            {
                sb.AppendLine(user.PrintInfo());
            }

            Console.WriteLine(sb.ToString());
        }

        public void SearchUserByPhone(IList<string> parameters)
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
