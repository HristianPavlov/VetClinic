namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface ICommandExample
    {
        void CreateUser(IList<string> parameters);

        void RemoveUser(IList<string> parameters);

        void GetUserPets(IList<string> parameters);
    }
}
