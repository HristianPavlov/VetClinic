using System.Collections.Generic;
using VetClinic.Data.Contracts;

namespace VetClinic.Data.Repositories
{
    public interface IEmployeeRepository
    {
        ICollection<IEmployee> Employees { get; }

        void CreateEmployee(IEmployee employee);

        void DeleteEmployee(string id);
    }
}
