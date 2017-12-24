using System.Collections.Generic;

namespace VetClinic.Data.Contracts
{
    public interface IPetsOwnerRepository
    {
        ICollection<IPetOwner> PetsOwners { get; }

        IPetOwner GetById(string ownerId);

        void AddOwner(IPetOwner petOwner);

        void RemoveOwner(string id);
    }
}
