using System.Collections.Generic;

namespace VetClinic.Commands.Contracts
{
    public interface IPetCommand
    {
        void CreatePet(IList<string> parameters);

        void DeletePet(IList<string> parameters);

        void ListPets();
    }
}
