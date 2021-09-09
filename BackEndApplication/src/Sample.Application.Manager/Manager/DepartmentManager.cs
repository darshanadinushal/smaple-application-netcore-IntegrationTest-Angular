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
    public class DepartmentManager : IDepartmentManager
    {
        private readonly ILogger<DepartmentManager> _logger;

        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentManager(ILogger<DepartmentManager> logger, IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _departmentRepository.GetDepartmentAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
