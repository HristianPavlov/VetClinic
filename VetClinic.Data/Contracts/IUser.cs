namespace VetClinic.Data.Contracts
{
    using System.Collections.Generic;

    public interface IUser : IPerson
    {
        ICollection<IAnimal> Pets { get; }

        // TODO
        // IList<IService> UsedServices { get; }

        void AddPet(IAnimal pet);

        void RemovePet(IAnimal pet);

        void PayForServices();

        string ListUserPets();

        string PrintInfo();
    }
}
