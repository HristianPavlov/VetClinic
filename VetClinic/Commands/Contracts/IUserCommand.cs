namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface IUserCommand
    {
        void CreateUser(IList<string> parameters);

        void DeleteUser(IList<string> parameters);

        void ListUserPets(IList<string> parameters);

        void CreatePet(IList<string> parameters);

        void DeletePet(IList<string> parameters);

        void SearchUserByPhone(IList<string> parameters);

        void ListUsers();
    }
}
