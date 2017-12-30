namespace VetClinic.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IUserRepository
    {
        ICollection<IUser> Users { get; }

        void CreateUser(IUser user);

        void DeleteUser(string id);
    }
}
