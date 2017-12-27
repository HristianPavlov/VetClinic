using System.Collections.Generic;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Repositories
{
    public interface IUserRepository
    {
        ICollection<IUser> Users { get; }

        void AddUser(IUser user);

        void RemoveUser(string id);
    }
}
