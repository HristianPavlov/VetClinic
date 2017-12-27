namespace VetClinic.Data.Repositories
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IAnimalRepository
    {
        ICollection<IAnimal> Animals { get; }

        void AddAnimal(string userId, IAnimal animal);

        void RemoveAnimal(string id);
    }
}
