namespace VetClinic.Data.Repositories.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories.Contracts;

    public class PetRepository : IPetRepository
    {
        private readonly ICollection<IPet> pets;
        private readonly IUserRepository users;

        public PetRepository(IUserRepository users)
        {
            this.users = users;
            this.pets = new List<IPet>();
        }

        public ICollection<IPet> Pets => new List<IPet>(this.pets);

        public IUserRepository Users => users;

        public void CreatePet(string userPhone, IPet pet)
        {
            if (pet == null)
            {
                throw new ArgumentNullException("This pet is null");
            }

            var petExists = this.pets.Any(a => a.Id == pet.Id);

            if (petExists)
            {
                throw new ArgumentException("This pet already exists in database");
            }

            this.pets.Add(pet);
        }

        public IPet GetById(string id) => this.pets.SingleOrDefault(a => a.Id == id);


        public void DeletePet(string userPhone, IPet pet)
        {
            if (pet == null)
            {
                throw new ArgumentNullException("This pet is null");
            }

            var petExists = this.pets.Any(a => a.Id == pet.Id);

            if (!petExists)
            {
                throw new ArgumentException("This pet does not exists in database");
            }

            this.pets.Remove(pet);
        }
    }
}
