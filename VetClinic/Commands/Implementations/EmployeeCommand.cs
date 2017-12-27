namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Data.Common.Enums;
    using VetClinic.Data.Repositories;
    using VetClinic.Factories.Contracts;

    public class EmployeeCommand : IEmployeeCommand
    {
        private readonly IPersonFactory personFactory;
        private readonly IEmployeeRepository employeeDb;

        public EmployeeCommand(IPersonFactory personFactory, IEmployeeRepository staffDb)
        {
            this.personFactory = personFactory;
            this.employeeDb = staffDb;
        }

        public void CreateEmployee(IList<string> parameters)
        {
            var firstName = parameters[1];
            var lastName = parameters[2];
            var phoneNumber = parameters[3];
            var email = parameters[4];
            var role = (RoleType)Enum.Parse(typeof(RoleType), parameters[4]);

            var newEmployee = this.personFactory.CreateStaffPerson(firstName, lastName, phoneNumber, email, role);
        }

        public void RemoveEmployee(IList<string> parameters)
        {
            var employeeId = parameters[1];

            var employee = this.employeeDb.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                Console.WriteLine("Employee not found");
                return;
            }

            this.employeeDb.DeleteEmployee(employeeId);
            Console.WriteLine($"Person {employee.FirstName} {employee.LastName} successfully removed from database");
        }

        public void ListEmployees()
        {
            if (this.employeeDb.Employees.Count == 0)
            {
                Console.WriteLine("No employee registered yet");
                return;
            }

            var sb = new StringBuilder();

            sb.AppendLine("All employees:");

            foreach (var employee in this.employeeDb.Employees)
            {
                sb.AppendLine(employee.PrintInfo());
            }

            Console.WriteLine(sb.ToString());
        }

        public string SearchByPhone(IList<string> parameters)
        {
            var phone = parameters[1];

            var employee = this.employeeDb.Employees.FirstOrDefault(e => e.PhoneNumber == phone);

            if (employee == null)
            {
                return $"Employee with phone number {phone} was not found! Please proceed to register";
            }
            else
            {
                Console.WriteLine($"Emplyoee {employee.FirstName} {employee.LastName} was found with phone number {phone}");
                return $"Emplyoee Info: {employee.PrintInfo()}";
            }
        }
    }
}
