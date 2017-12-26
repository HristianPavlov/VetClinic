namespace VetClinic.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Data.Contracts;

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

        public void AddAnimal(string userId, IAnimal animal)
        {
            var animalExists = this.animals.Any(u => u.Id == animal.Id);

            if (animalExists)
            {
                throw new ArgumentException("This animal already exists in database");
            }
            this.animals.Add(animal);
            
            // find user and add animal to him
            var user = this.usersDb.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("This user does not exists in database");
            }

            user.AddPet(animal);
        }

        public IAnimal GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAnimal(string id)
        {
            throw new NotImplementedException();
        }
    }
}
