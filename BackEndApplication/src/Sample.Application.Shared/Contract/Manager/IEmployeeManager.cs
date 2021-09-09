using Sample.Application.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Shared.Contract.Manager
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(CancellationToken cancellationToken);

        Task<Employee> SaveEmployeesAsync(Employee employee, CancellationToken cancellationToken);

        Task<Employee> GetEmployeeByIdAsync(int employeeId, CancellationToken cancellationToken);

        Task<bool> DeleteEmployeeByIdAsync(int employeeId, CancellationToken cancellationToken);


    }
}
