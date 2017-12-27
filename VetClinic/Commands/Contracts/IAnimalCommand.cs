using System.Collections.Generic;

namespace VetClinic.Commands.Contracts
{
    public interface IAnimalCommand
    {
        void CreateAnimal(IList<string> parameters);

        void DeleteAnimal(IList<string> parameters);

        string ListPets();
    }
}
