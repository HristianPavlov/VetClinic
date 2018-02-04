using System.Collections.Generic;

namespace VetClinic.Commands.Contracts
{
    public interface IEmployeeCommand
    {
        void CreateEmployee(IList<string> parameters);

        void DeleteEmployee(IList<string> parameters);

        void ListEmployees();

        void SearchEmployeeByPhone(IList<string> parameters);
    }
}
