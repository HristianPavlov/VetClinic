namespace VetClinic.Data.Repositories
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IAnimalRepository
    {
        IDictionary<IUser, IAnimal> Animals { get; }

        IAnimal GetById(string id);

        void CreateCat(IUser user, ICat cat);

        void CreateDog(IUser user, IDog dog);

        void CreateHamster(IUser user, IHamster hamster);

        void RemoveAnimal(string id);
    }
}
