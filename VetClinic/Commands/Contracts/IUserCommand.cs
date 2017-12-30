namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface IUserCommand
    {
        void CreateUser(IList<string> parameters);

        void DeleteUser(IList<string> parameters);

        void ListUserPets(IList<string> parameters);

        void CreateAnimal(IList<string> parameters);

        void DeleteAnimal(IList<string> parameters);

        void SearchUserByPhone(IList<string> parameters);

        void ListUsers();
    }
}
