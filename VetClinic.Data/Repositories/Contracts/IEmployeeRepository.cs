namespace VetClinic.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using VetClinic.Data.Contracts;

    public interface IEmployeeRepository
    {
        ICollection<IEmployee> Employees { get; }

        void CreateEmployee(IEmployee employee);

        void DeleteEmployee(string id);
    }
}
