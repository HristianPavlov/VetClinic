namespace VetClinic.Data.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Enums;

    public interface IPet
    {
        string Id { get; }

        string Name { get; }

        int Age { get; }

        string OwnerPhoneNumber { get; set; }

        string PrintInfo();

        AnimalType Type { get; }

        AnimalGenderType Gender { get; }
        ICollection<IService> Services { get; }

        void AddServices(IService service);
    }
}