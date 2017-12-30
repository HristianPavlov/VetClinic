namespace VetClinic.Data.Repositories.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories.Contracts;

    public class UserRepository : IUserRepository
    {
        public readonly ICollection<IUser> users;

        public UserRepository()
        {
            this.users = new List<IUser>();
        }

        public ICollection<IUser> Users => new List<IUser>(this.users);

        public void CreateUser(IUser user)
        {
            var userExists = this.users.Any(u => u.Id == user.Id);

            if (userExists)
            {
                Console.WriteLine(("This user already exists in database"));
                return;
            }
            this.users.Add(user);
        }

        public void DeleteUser(string id)
        {
            var user = this.users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                Console.WriteLine(("This user does not exists in database"));
                return;
            }
            this.users.Remove(user);
        }
        
    }
}
