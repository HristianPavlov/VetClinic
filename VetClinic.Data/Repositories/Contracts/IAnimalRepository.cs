namespace VetClinic.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IAnimalRepository
    {
        ICollection<IAnimal> Animals { get; }

        void CreateAnimal(string userPhone, IAnimal animal);

        void DeteleAnimal(string userPhone, IAnimal animal);

        IAnimal GetById(string id);
    }
}
