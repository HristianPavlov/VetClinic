namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface IUserCommand
    {
        void CreateUser(IList<string> parameters);

        void RemoveUser(IList<string> parameters);

        void GetUserPets(IList<string> parameters);

        void ListAllUsers();
    }
}
