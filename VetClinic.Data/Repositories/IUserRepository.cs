using System.Collections.Generic;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Repositories
{
    public interface IUserRepository
    {
        ICollection<IUser> Users { get; }

        IUser GetById(string id);

        void AddUser(IUser user);

        void RemoveUser(string id);

    }
}
