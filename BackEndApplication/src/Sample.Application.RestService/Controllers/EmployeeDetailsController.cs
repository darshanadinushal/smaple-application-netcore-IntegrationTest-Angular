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
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly ILogger<EmployeeDetailsController> _logger;

        private readonly IEmployeeManager _employeeManager;
        public EmployeeDetailsController(ILogger<EmployeeDetailsController> logger, IEmployeeManager employeeManager)
        {
            _logger = logger;
            _employeeManager = employeeManager;
        }


        [HttpGet]
        public async Task<Employee> Get(int id ,CancellationToken cancellationToken)
        {
            try
            {
                return await _employeeManager.GetEmployeeByIdAsync(id ,cancellationToken);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
