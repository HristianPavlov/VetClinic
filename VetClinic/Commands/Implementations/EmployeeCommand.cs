namespace VetClinic.Commands.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using VetClinic.Commands.Contracts;
    using VetClinic.Common;
    using VetClinic.Common.ConsoleServices.Contracts;
    using VetClinic.Data.Enums;
    using VetClinic.Data.Repositories.Contracts;
    using VetClinic.Factories.Contracts;

    public class EmployeeCommand : Command, IEmployeeCommand
    {
        private readonly IPersonFactory personFactory;
        private readonly IEmployeeRepository employeeDb;
        private readonly IWriter writer;

        public EmployeeCommand(IPersonFactory personFactory, IEmployeeRepository staffDb, IWriter writer)
        {
            this.personFactory = personFactory;
            this.employeeDb = staffDb;
            this.writer = writer;
        }

        public void CreateEmployee(IList<string> parameters)
        {
            var firstName = parameters[1];
            var lastName = parameters[2];
            var phoneNumber = parameters[3];
            var email = parameters[4];
            var role = (RoleType)Enum.Parse(typeof(RoleType), parameters[4].ToLower());

            var newEmployee = this.personFactory.CreateEmployee(firstName, lastName, phoneNumber, email, role);
        }

        public void DeleteEmployee(IList<string> parameters)
        {
            var employeeId = parameters[1];

            var employee = this.employeeDb.Employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            this.employeeDb.DeleteEmployee(employeeId);
            this.OnMessage($"Person {employee.FirstName} {employee.LastName} successfully deleted");
        }

        public void ListEmployees()
        {
            if (this.employeeDb.Employees.Count == 0)
            {
                throw new ArgumentException("No employee registered yet");
            }

            var sb = new StringBuilder();

            sb.AppendLine("All employees:");

            foreach (var employee in this.employeeDb.Employees)
            {
                sb.AppendLine(employee.PrintInfo());
            }

            this.writer.WriteLine(sb.ToString());
        }

        public void SearchEmployeeByPhone(IList<string> parameters)
        {
            var phone = parameters[1];

            var employee = this.employeeDb.Employees.FirstOrDefault(e => e.PhoneNumber == phone);

            if (employee == null)
            {
                this.writer.WriteLine($"Employee with phone number {phone} was not found! Please proceed to register");
            }
            else
            {
                this.writer.WriteLine($"Emplyoee {employee.FirstName} {employee.LastName} was found with searched phone number {phone}");
                this.writer.WriteLine($"Emplyoee Info: {employee.PrintInfo()}");
            }
        }

        public override void Create(IList<string> parameters)
        {
            CreateEmployee(parameters);
        }

        public override void Delete(IList<string> parameters)
        {
            DeleteEmployee(parameters);
        }
    }
}
