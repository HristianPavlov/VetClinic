using System.Collections.Generic;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Repositories
{
    public interface IStaffRepository
    {
        ICollection<IStaffPerson> Staff { get; }

        void AddStaffPerson(IStaffPerson user);

        void RemoveStaffPerson(string id);
    }
}
