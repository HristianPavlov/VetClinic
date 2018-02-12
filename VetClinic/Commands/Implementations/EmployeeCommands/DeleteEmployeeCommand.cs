using System;
using System.Linq;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.EmployeeCommands
{
    public class DeleteEmployeeCommand : AbstractCommand, ICommand
    {
        private readonly IEmployeeRepository employees;
        private readonly IWriter writer;

        public DeleteEmployeeCommand(IEmployeeRepository employees, IWriter writer)
        {
            this.employees = employees ?? throw new ArgumentNullException("employees");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            DeleteEmployee();
        }

        private void DeleteEmployee()
        {
            var parameters = this.Parameters;
            var employeeId = parameters[1];
            var employee = this.employees.Employees.SingleOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException($"{employee.FirstName} {employee.LastName} not found");
            }

            this.employees.DeleteEmployee(employeeId);

            this.writer.WriteLine($"{employee.FirstName} {employee.LastName} successfully deleted");
        }
    }
}
