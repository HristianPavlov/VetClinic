using System.Collections.Generic;

namespace VetClinic.Data.Contracts
{
    public interface IPetOwner: IPerson
    {
        ICollection<IAnimal> Pets { get; }

        decimal Wallet { get; }

        void AddPet(IAnimal pet);

        void RemovePet(IAnimal pet);

        void PayForServices(decimal cost);

        void BuyMedicine(decimal cost);

        void ListAllPets();

    }
}
