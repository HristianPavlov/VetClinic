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

        void CreateCat(IUser user, ICat cat);

        void CreateDog(IUser user, IDog dog);

        void CreateHamster(IUser user, IHamster hamster);

        void RemoveAnimal(string id);
    }
}
