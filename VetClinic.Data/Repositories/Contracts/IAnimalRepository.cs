namespace VetClinic.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IAnimalRepository
    {
        ICollection<IAnimal> Animals { get; }

        void CreateAnimal(string userId, IAnimal animal);

        void DeteleAnimal(IAnimal animal,string userPhoneNumber);

        IAnimal GetById(string id);
    }
}
