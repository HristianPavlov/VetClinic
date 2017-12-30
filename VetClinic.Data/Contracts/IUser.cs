namespace VetClinic.Data.Contracts
{
    using System.Collections.Generic;

    public interface IUser : IPerson
    {
        ICollection<IAnimal> Pets { get; }

         decimal Bill { get ; set ; }

        void AddPet(IAnimal pet);

        void RemovePet(IAnimal pet);

        string ListUserPets();

        string PrintInfo();
    }
}
