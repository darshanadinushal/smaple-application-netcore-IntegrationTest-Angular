using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Application.Shared.Contract.Manager;
using Sample.Application.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeManager employeeManager)
        {
            _logger = logger;
            _employeeManager = employeeManager;
        }


        [HttpGet]
        public async Task<IEnumerable<Employee>> Get(CancellationToken cancellationToken)
        {
            try
            {
                return await _employeeManager.GetEmployeesAsync(cancellationToken);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public async Task<Employee> Post([FromBody]Employee employee , CancellationToken cancellationToken)
        {
            try
            {
                if (employee == null)
                    throw new Exception("Bad request ,provide employee is null");
                
                return await _employeeManager.SaveEmployeesAsync(employee, cancellationToken);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpDelete]
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                if (id <=0)
                    throw new Exception("Bad request ,provide employee is null");

                return await _employeeManager.DeleteEmployeeByIdAsync(id, cancellationToken);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


    }
}
