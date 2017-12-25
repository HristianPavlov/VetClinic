using System;
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

        public IUser GetById(string ownerId)
        {
            return this.Users.FirstOrDefault(o => o.Id == ownerId);
        }

        public void AddUser(IUser user)
        {
            var userExists = this.Users.Any(o => o.Id == user.Id);

            if (userExists)
            {
                throw new ArgumentException("This user exists in database");
            }
            this.Users.Add(user);
        }

        public void RemoveUser(string id)
        {
            var user = this.Users.FirstOrDefault(o => o.Id == id);

            if (user == null)
            {
                throw new ArgumentException("This user does not exists in database");
            }
            this.Users.Remove(user);
        }
    }
}
