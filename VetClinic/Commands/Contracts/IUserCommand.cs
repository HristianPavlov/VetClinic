namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface IUserCommand
    {
        void CreateUser(IList<string> parameters);

        void DeleteUser(IList<string> parameters);

        void ListUserPets(IList<string> parameters);

        string SearchByPhone(IList<string> parameters);

        void ListUsers();
    }
}
