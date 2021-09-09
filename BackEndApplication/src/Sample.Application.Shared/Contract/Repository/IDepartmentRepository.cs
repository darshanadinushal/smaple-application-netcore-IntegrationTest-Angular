using Sample.Application.Shared.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Shared.Contract.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartmentAsync(CancellationToken cancellationToken);
    }
}
