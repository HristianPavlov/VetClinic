﻿using System;
using System.Collections.Generic;
using System.Linq;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ICollection<IUser> users;

        public UserRepository()
        {
            this.users = new List<IUser>();
        }

        public ICollection<IUser> Users => new List<IUser>(this.users);

        public IUser GetById(string id)
        {
            return this.users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(IUser user)
        {
            var userExists = this.users.Any(u => u.Id == user.Id);

            if (userExists)
            {
                throw new ArgumentException("This user already exists in database");
            }
            this.users.Add(user);
        }

        public void RemoveUser(string id)
        {
            var user = this.users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentException("This user does not exists in database");
            }
            this.users.Remove(user);
        }
    }
}
