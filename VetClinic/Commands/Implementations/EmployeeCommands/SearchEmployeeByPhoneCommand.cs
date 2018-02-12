using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.EmployeeCommands
{
    public class SearchEmployeeByPhoneCommand : AbstractCommand, ICommand
    {
        private readonly IEmployeeRepository employees;
        private readonly IWriter writer;

        public SearchEmployeeByPhoneCommand(IEmployeeRepository employees, IWriter writer)
        {
            this.employees = employees ?? throw new ArgumentNullException("employees");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            var parameters = this.Parameters;
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
