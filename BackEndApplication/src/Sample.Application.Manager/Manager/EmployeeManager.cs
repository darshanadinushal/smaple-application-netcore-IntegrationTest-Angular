using Microsoft.Extensions.Logging;
using Sample.Application.Shared.Contract.Manager;
using Sample.Application.Shared.Contract.Repository;
using Sample.Application.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Manager.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly ILogger<EmployeeManager> _logger;

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(ILogger<EmployeeManager> logger , IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _employeeRepository.GetEmployeesAsync(cancellationToken);

            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public async Task<Employee> SaveEmployeesAsync(Employee employee ,CancellationToken cancellationToken)
        {
            try
            {
                if (employee.Id > 0)
                {
                    return await _employeeRepository.UpdateEmployeesAsync(employee ,cancellationToken);
                }
                else
                {
                    return await _employeeRepository.SaveEmployeesAsync(employee, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<Employee> GetEmployeeByIdAsync(int employeeId, CancellationToken cancellationToken)
        {
            try
            {
                if (employeeId > 0)
                {
                    return await _employeeRepository.GetEmployeeByIdAsync(employeeId, cancellationToken);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployeeByIdAsync(int employeeId, CancellationToken cancellationToken)
        {
            try
            {
                if (employeeId > 0)
                {
                    return await _employeeRepository.DeleteEmployeeByIdAsync(employeeId, cancellationToken);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
