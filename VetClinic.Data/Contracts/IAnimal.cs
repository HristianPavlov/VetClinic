using VetClinic.Data.Common.Enums;
using VetClinic.Data.Models;

namespace VetClinic.Data.Contracts
{
    public interface IAnimal
    {
        string Id { get; }

        string Name { get; }

        int Age { get; }

        PetOwner Owner { get; }

        AnimalType Type { get; }

        AnimalGenderType Gender { get; }
    }
}