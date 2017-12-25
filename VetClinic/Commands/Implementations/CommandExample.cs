namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Repositories;
    using VetClinic.Factories.Contracts;


    public class CommandExample : ICommandExample
    {
        private readonly IPersonFactory personFactory;
        private readonly IUserRepository userRepository;

        public CommandExample(IPersonFactory personFactory, IUserRepository petsOwnerRepository)
        {
            this.personFactory = personFactory;
            this.userRepository = petsOwnerRepository;
        }

        public void CreateUser(IList<string> parameters)
        {
            var firstName = parameters[1];
            var lastName = parameters[2];
            var phoneNumber = parameters[3];
            var email = parameters[4];

            var newUser = this.personFactory.CreateUser(firstName, lastName, phoneNumber, email); // TODO children could not be evaluated

            this.userRepository.AddUser(newUser);
            Console.WriteLine($"User {firstName} {lastName} successfully created");
        }

        public void RemoveUser(IList<string> parameters)
        {
            var userId = parameters[1];

            var user = this.userRepository.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            this.userRepository.RemoveUser(userId);
            Console.WriteLine($"User {user.FirstName} {user.LastName} successfully removed from database");
        }

        public void GetUserPets(IList<string> parameters)
        {
            var userId = parameters[1];

            var user = this.userRepository.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            user.ListAllPets();
        }
    }
}
