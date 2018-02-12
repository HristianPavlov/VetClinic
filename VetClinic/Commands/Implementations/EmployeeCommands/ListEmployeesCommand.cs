using System;
using System.Text;
using VetClinic.Commands.Contracts;
using VetClinic.Data.Repositories.Contracts;
using VetClinic.Factories.Contracts;
using VetClinic.Providers.Contracts;

namespace VetClinic.Core.Commands.Implementations.EmployeeCommands
{
    public class ListEmployeesCommand : AbstractCommand, ICommand
    {
        private readonly IEmployeeRepository employees;
        private readonly IWriter writer;

        public ListEmployeesCommand(IPersonFactory personFactory, IEmployeeRepository employees, IWriter writer)
        {
            this.employees = employees ?? throw new ArgumentNullException("employees");
            this.writer = writer ?? throw new ArgumentNullException("writer");
        }

        public override void Execute()
        {
            ListEmployees();
        }

        private void ListEmployees()
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
    }
}
