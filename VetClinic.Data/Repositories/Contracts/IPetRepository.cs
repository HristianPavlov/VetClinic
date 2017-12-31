namespace VetClinic.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IPetRepository
    {
        ICollection<IPet> Pets { get; }

        void CreatePet(string userPhone, IPet pet);

        void DetelePet(string userPhone, IPet pet);

        IPet GetById(string id);
    }
}
