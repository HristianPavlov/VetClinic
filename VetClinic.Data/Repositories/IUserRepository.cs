using System.Collections.Generic;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Repositories
{
    public interface IUserRepository
    {
        ICollection<IUser> Users { get; }

        void CreateUser(IUser user);

        void DeleteUser(string id);
    }
}
