using System.Collections.Generic;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Repositories
{
    public interface IEmployeeRepository
    {
        ICollection<IEmployee> Employees { get; }

        void AddEmployee(IEmployee employee);

        void RemoveEmployee(string id);
    }
}
