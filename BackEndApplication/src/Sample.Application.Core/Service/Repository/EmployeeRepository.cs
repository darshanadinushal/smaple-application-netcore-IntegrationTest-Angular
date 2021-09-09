using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sample.Application.Core.Service.DBModel;
using Sample.Application.Shared.Contract.Repository;
using Sample.Application.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Core.Service.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> _logger;

        private readonly SampledbContext _sampledbContext;

        private readonly IMapper _mapper;
        public EmployeeRepository(ILogger<EmployeeRepository> logger , SampledbContext sampledbContext , IMapper mapper)
        {
            _logger = logger;
            _sampledbContext = sampledbContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Employee>> GetEmployeesAsync(CancellationToken cancellationToken)
        {
            try
            {
                var employeList= await _sampledbContext.TblEmployee.Where(x => x.IsActive == true).Include(x=>x.Department).ToListAsync(cancellationToken);
                var employee= _mapper.Map<IEnumerable<TblEmployee>, IEnumerable<Employee>>(employeList);
                return employee;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId ,CancellationToken cancellationToken)
        {
            try
            {
                var tblEmploye = await _sampledbContext.TblEmployee.SingleOrDefaultAsync(x => x.IsActive == true && x.Id== employeeId , cancellationToken);
                var employee = _mapper.Map<TblEmployee, Employee>(tblEmploye);
                return employee;
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
                var existedEmployee = await _sampledbContext.TblEmployee.Where(x => x.Id == employeeId && x.IsActive == true).FirstOrDefaultAsync(cancellationToken);
                if (existedEmployee != null)
                {
                    existedEmployee.IsActive = false;
                    _sampledbContext.TblEmployee.Update(existedEmployee);
                    await _sampledbContext.SaveChangesAsync(cancellationToken);
                }
                   
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<Employee> SaveEmployeesAsync(Employee employee , CancellationToken cancellationToken)
        {
            try
            {
                var tblEmployee = _mapper.Map<Employee, TblEmployee>(employee);
                tblEmployee.CreatedBy = "Admin";
                tblEmployee.CreatedDate = DateTime.Now;
                tblEmployee.ModifitedBy = null;
                tblEmployee.ModifitedDate = null;
                tblEmployee.IsActive = true;
                tblEmployee.Department = null;
                _sampledbContext.TblEmployee.Add(tblEmployee);
                await _sampledbContext.SaveChangesAsync(cancellationToken);
                return _mapper.Map<TblEmployee, Employee>(tblEmployee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<Employee> UpdateEmployeesAsync(Employee employee, CancellationToken cancellationToken)
        {
            try
            {
                var existedEmployee = await _sampledbContext.TblEmployee.Where(x => x.Id == employee.Id && x.IsActive == true).FirstOrDefaultAsync(cancellationToken);
                if (existedEmployee != null)
                {
                    existedEmployee.FirstName = employee.FirstName;
                    existedEmployee.LastName = employee.LastName;
                    existedEmployee.Address = employee.Address;
                    existedEmployee.DepartmentId = employee.DepartmentId;
                    existedEmployee.Email = employee.Email;
                    existedEmployee.Phone = employee.Phone;
                    existedEmployee.Salary = employee.Salary;
                    existedEmployee.ModifitedBy = "Admin";
                    existedEmployee.ModifitedDate = DateTime.Now;
                    existedEmployee.IsActive = true;
                    existedEmployee.Department = null;
                    _sampledbContext.TblEmployee.Update(existedEmployee);
                    await _sampledbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<TblEmployee, Employee>(existedEmployee);
                }
                else
                {
                    throw new Exception("There is no employee existed to update");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
