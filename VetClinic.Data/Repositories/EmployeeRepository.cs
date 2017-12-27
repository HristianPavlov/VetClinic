namespace VetClinic.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VetClinic.Data.Contracts;

    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly ICollection<IEmployee> employees;

        public EmployeeRepository()
        {
            this.employees = new List<IEmployee>();
        }

        public ICollection<IEmployee> Employees => new List<IEmployee>(this.employees);

        public void AddEmployee(IEmployee employee)
        {
            var employeeExist = this.employees.Any(p => p.Id == employee.Id);

            if (employeeExist)
            {
                throw new ArgumentException("This employee already exists in database");
            }
            this.employees.Add(employee);
        }

        public void RemoveEmployee(string id)
        {
            var employee = this.employees.FirstOrDefault(p => p.Id == id);

            if (employee == null)
            {
                throw new ArgumentException("This employee does not exists in database");
            }
            this.employees.Remove(employee);
        }
    }
}
