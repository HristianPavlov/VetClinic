using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Enums;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.EmployeeCommands
{
    public class CreateEmployeeCommand : AbstractCommand, ICommand
    {
        private readonly IPersonFactory personFactory;
        private readonly IEmployeeRepository employees;
        private readonly IWriter writer;

        public CreateEmployeeCommand(IPersonFactory personFactory, IEmployeeRepository employees, IWriter writer)
        {
            this.personFactory = personFactory ?? throw new ArgumentNullException("personFactory");
            this.employees = employees ?? throw new ArgumentNullException("employees");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            CreateEmployee();
        }

        private void CreateEmployee()
        {
            var parameters = this.Parameters;
            var firstName = parameters[1];
            var lastName = parameters[2];
            var phoneNumber = parameters[3];
            var email = parameters[4];
            var role = (RoleType)Enum.Parse(typeof(RoleType), parameters[5].ToLower());

            var employeeFound = this.employees.Employees.SingleOrDefault(e => e.PhoneNumber == phoneNumber);

            if (employeeFound != null)
            {
                throw new ArgumentNullException($"{employeeFound.FirstName} {employeeFound.LastName} already exists");
            }

            var newEmployee = this.personFactory.CreateEmployee(firstName, lastName, phoneNumber, email, role);
            this.employees.CreateEmployee(newEmployee);

            this.writer.WriteLine($"{newEmployee.FirstName} {newEmployee.LastName} successfully created");
        }
    }
}
