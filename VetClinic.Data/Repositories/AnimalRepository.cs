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

        public void CreateAnimal(string userPhone, IAnimal animal)
        {
            var animalExists = this.animals.Any(u => u.Id == animal.Id);

            if (animalExists)
            {
                Console.WriteLine(("This animal already exists in database"));
                return;
            }

            this.animals.Add(animal);
            
            // TODO to be extracted
            var user = this.usersDb.Users.FirstOrDefault(u => u.PhoneNumber == userPhone);

            if (user == null)
            {
                Console.WriteLine(("This user does not exists in database"));
                return;
            }

            user.AddPet(animal);
        }

        public IAnimal GetById(string id) => this.animals.FirstOrDefault(a => a.Id == id);

        public void DeteleAnimal(string id)
        {
            var animal = this.animals.FirstOrDefault(a => a.Id == id);

            if (animal == null)
            {
                Console.WriteLine("Animal not found");
                return;
            }

            this.animals.Remove(animal);
        }
    }
}
