namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface IUserCommand
    {
        void CreateUser(IList<string> parameters);

        void DeleteUser(IList<string> parameters);

        void ListUserPets(IList<string> parameters);

        void SearchByPhone(IList<string> parameters);

        void ListUsers();

        void ShowServices();

        void SelectService(string id);

    }
}
