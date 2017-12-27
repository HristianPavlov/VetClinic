namespace VetClinic.Data.Repositories
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IAnimalRepository
    {
        ICollection<IAnimal> Animals { get; }

        void CreateAnimal(string userId, IAnimal animal);

        void DeteleAnimal(string id);
    }
}
