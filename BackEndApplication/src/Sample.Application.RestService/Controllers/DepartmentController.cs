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
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;

        private readonly IDepartmentManager _departmentManager;
        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentManager departmentManager)
        {
            _logger = logger;
            _departmentManager = departmentManager;
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> GetAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _departmentManager.GetDepartmentsAsync(cancellationToken);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
