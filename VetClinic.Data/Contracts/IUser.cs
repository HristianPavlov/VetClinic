namespace VetClinic.Data.Contracts
{
    using System.Collections.Generic;

    public interface IUser : IPerson
    {
        ICollection<IAnimal> Pets { get; }

        void AddPet(IAnimal pet);

        void RemovePet(IAnimal pet);

        void PayForServices(decimal cost);

        void BuyMedicine(decimal cost);

        string ListUserPets();

        string PrintInfo();

    }
}
