﻿namespace VetClinic.Commands.Implementations
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

            this.userDb.AddUser(newUser);
            Console.WriteLine($"User {firstName} {lastName} successfully created");
        }

        public void RemoveUser(IList<string> parameters)
        {
            var userId = parameters[1];

            var user = this.userDb.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            this.userDb.RemoveUser(userId);
            Console.WriteLine($"User {user.FirstName} {user.LastName} successfully removed from database");
        }

        public void GetUserPets(IList<string> parameters)
        {
            var userId = parameters[1];

            var user = this.userDb.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            user.ListAllPets();
        }

        public string ListAllUsers() // TODO not working
        {
            if (this.userDb.Users.Count == 0)
            {
                return "no users registered";
            }

            var sb = new StringBuilder();

            sb.AppendLine("All users:");

            var users = this.userDb
                            .Users
                            .Select(u => new
                            {
                                u.FirstName,
                                u.LastName,
                                u.PhoneNumber,
                                u.Email,
                                Pets = u.Pets.Select(p => new
                                {
                                     p.Name,
                                     p.Age,
                                     p.Type,
                                     p.Gender
                                })
                            })
                            .ToList();
                     

            users.ForEach(u => sb.AppendLine(u.ToString()));

            return sb.ToString();
        }
    }
}
