namespace VetClinic.Data.Repositories.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories.Contracts;

    public class AnimalRepository : IAnimalRepository
    {
        private readonly ICollection<IPet> pets;
        private readonly IUserRepository usersDb;

        public AnimalRepository(IUserRepository users)
        {
            this.usersDb = users;
            this.pets = new List<IPet>();
        }
        public ICollection<IPet> Pets => new List<IPet>(this.pets);

        public void CreatePet(string userPhone, IPet pet)
        {
            var petExists = this.pets.Any(a => a.Id == pet.Id);

            if (petExists)
            {
                throw new ArgumentException("This pet already exists in database");
            }

            this.pets.Add(pet);
        }

        public IPet GetById(string id) => this.pets.FirstOrDefault(a => a.Id == id);


        public void DetelePet(string userPhone, IPet pet)
        {
            var petExists = this.pets.Any(a => a.Id == pet.Id);

            if (petExists)
            {
                throw new ArgumentException("This pet already exists in database");
            }

            this.pets.Remove(pet);
        }
    }
}
