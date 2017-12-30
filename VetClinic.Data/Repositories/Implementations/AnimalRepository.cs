namespace VetClinic.Data.Repositories.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Data.Contracts;
    using VetClinic.Data.Repositories.Contracts;

    public class AnimalRepository : IAnimalRepository
    {
        private readonly ICollection<IAnimal> animals;
        private readonly IUserRepository usersDb;

        public AnimalRepository(IUserRepository users)
        {
            this.usersDb = users;
            this.animals = new List<IAnimal>();
        }
        public ICollection<IAnimal> Animals => new List<IAnimal>(this.animals);

        public void CreateAnimal(string userPhone, IAnimal animal)
        {
            var animalExists = this.animals.Any(a => a.Id == animal.Id);

            if (animalExists)
            {
                throw new ArgumentException("This animal already exists in database");
            }

            this.animals.Add(animal);
        }

        public IAnimal GetById(string id) => this.animals.FirstOrDefault(a => a.Id == id);


        public void DeteleAnimal(string userPhone, IAnimal animal)
        {
            var animalExists = this.animals.Any(a => a.Id == animal.Id);

            if (animalExists)
            {
                throw new ArgumentException("This animal already exists in database");
            }

            this.animals.Remove(animal);
        }
    }
}
