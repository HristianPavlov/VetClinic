namespace VetClinic.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public class AnimalRepository : IAnimalRepository
    {
        private readonly IDictionary<IUser, IAnimal> animals;

        public AnimalRepository()
        {
            this.animals = new Dictionary<IUser, IAnimal>();
        }
        public IDictionary<IUser, IAnimal> Animals => new Dictionary<IUser, IAnimal>(this.animals);

        public void CreateCat(IUser user, ICat cat)
        {
            throw new NotImplementedException();
        }

        public void CreateDog(IUser user, IDog dog)
        {
            throw new NotImplementedException();
        }

        public void CreateHamster(IUser user, IHamster hamster)
        {
            throw new NotImplementedException();
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
