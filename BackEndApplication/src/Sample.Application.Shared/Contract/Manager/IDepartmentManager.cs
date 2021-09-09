using Sample.Application.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Shared.Contract.Manager
{
    public interface IDepartmentManager
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync(CancellationToken cancellationToken);
    }
}
