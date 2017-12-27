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

        public void CreateEmployee(IEmployee employee)
        {
            var employeeExist = this.employees.Any(e => e.Id == employee.Id);

            if (employeeExist)
            {
                Console.WriteLine(("This employee already exists in database"));
                return;
            }
            this.employees.Add(employee);
        }

        public void DeleteEmployee(string id)
        {
            var employee = this.employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                Console.WriteLine(("This employee does not exists in database"));
                return;
            }
            this.employees.Remove(employee);
        }
    }
}
