using System;
using System.Collections.Generic;
using System.Linq;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Models
{
    public class PetsOwnerRepository : IPetsOwnerRepository
    {
        public readonly ICollection<IPetOwner> petsOwners;

        public PetsOwnerRepository()
        {
            this.petsOwners = new List<IPetOwner>();
        }

        public ICollection<IPetOwner> PetsOwners => new List<IPetOwner>(this.petsOwners);

        public IPetOwner GetById(string ownerId)
        {
            return this.PetsOwners.FirstOrDefault(o => o.Id == ownerId);
        }

        public void AddOwner(IPetOwner petOwner)
        {
            var petOwnerFound = this.PetsOwners.Any(o => o.Id == petOwner.Id);

            if (petOwnerFound)
            {
                throw new ArgumentException("This onwer exists in database");
            }
            this.PetsOwners.Add(petOwner);
        }

        public void RemoveOwner(string id)
        {
            var petOwner = this.PetsOwners.FirstOrDefault(o => o.Id == id);

            if (petOwner == null)
            {
                throw new ArgumentException("This onwer does not exists in database");
            }
            this.PetsOwners.Remove(petOwner);
        }
    }
}
