namespace VetClinic.Commands.Contracts
{
    using System.Collections.Generic;

    public interface IPetCommand
    {
        void CreatePet(IList<string> parameters);

        void DeletePet(IList<string> parameters);

        void ListPets();
    }
}
