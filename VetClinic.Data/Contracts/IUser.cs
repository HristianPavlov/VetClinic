namespace VetClinic.Data.Contracts
{
    using System.Collections.Generic;

    public interface IUser : IPerson
    {
        ICollection<IPet> Pets { get; }

         decimal Bill { get ; set ; }

        void AddPet(IPet pet);

        void RemovePet(IPet pet);

        string ListUserPets();

        string PrintInfo();
    }
}
