using System.Collections.Generic;
using VetClinic.Data.Common.Enums;

namespace VetClinic.Data.Contracts
{
    public interface IAnimal
    {
        string Id { get; }

        string Name { get; }

        int Age { get; }

        string OwnerPhoneNumber { get; set; }

        string PrintInfo();

        AnimalType Type { get; }

        AnimalGenderType Gender { get; }
        ICollection<IService> Services { get; }

        void addServices(IService service);
    }
}