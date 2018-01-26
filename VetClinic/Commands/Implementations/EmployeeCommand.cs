namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common.ConsoleServices.Contracts;
    using VetClinic.Data.Enums;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public class EmployeeCommand : IEmployeeCommand
    {
        private readonly IPersonFactory personFactory;
        private readonly IEmployeeRepository employees;
        private readonly IWriter writer;

        public EmployeeCommand(IPersonFactory personFactory, IEmployeeRepository employees, IWriter writer)
        {
            this.personFactory = personFactory;
            this.employees = employees;
            this.writer = writer;
        }

        public void CreateEmployee(IList<string> parameters)
        {
            var firstName = parameters[1];
            var lastName = parameters[2];
            var phoneNumber = parameters[3];
            var email = parameters[4];
            var role = (RoleType)Enum.Parse(typeof(RoleType), parameters[4].ToLower());

            var employeeFound = this.employees.Employees.SingleOrDefault(e => e.PhoneNumber == phoneNumber);

            if (employeeFound != null)
            {
                throw new ArgumentNullException($"{employeeFound.FirstName} {employeeFound.LastName} already exists");
            }

            var newEmployee = this.personFactory.CreateEmployee(firstName, lastName, phoneNumber, email, role);
        }

        public void DeleteEmployee(IList<string> parameters)
        {
            var employeeId = parameters[1];

            var employee = this.employees.Employees.SingleOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException($"{employee.FirstName} {employee.LastName} not found");
            }

            this.employees.DeleteEmployee(employeeId);
            this.writer.WriteLine($"{employee.FirstName} {employee.LastName} successfully deleted");
        }

        public void ListEmployees()
        {
            if (this.employees.Employees.Count == 0)
            {
                throw new NullReferenceException("No employee registered yet");
            }

            var sb = new StringBuilder();

            sb.AppendLine("All employees:");

            foreach (var employee in this.employees.Employees)
            {
                sb.AppendLine(employee.PrintInfo());
            }

            this.writer.WriteLine(sb.ToString());
        }

        public void SearchEmployeeByPhone(IList<string> parameters)
        {
            var phone = parameters[1];

            var employee = this.employees.Employees.SingleOrDefault(e => e.PhoneNumber == phone);

            if (employee == null)
            {
                this.writer.WriteLine($"Employee with phone number {phone} was not found! Please proceed to register");
            }
            else
            {
                this.writer.WriteLine($"{employee.FirstName} {employee.LastName} was found with searched phone number {phone}");
                this.writer.WriteLine($"Emplyoee Info: {employee.PrintInfo()}");
            }
        }
    }
}
