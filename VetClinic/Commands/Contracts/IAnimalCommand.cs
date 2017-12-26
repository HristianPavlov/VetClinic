using System.Collections.Generic;

namespace VetClinic.Commands.Contracts
{
    public interface IAnimalCommand
    {
        void CreateAnimal(IList<string> parameters);

        void RemoveAnimal(IList<string> parameters);

        string ListAllPets();
    }
}
