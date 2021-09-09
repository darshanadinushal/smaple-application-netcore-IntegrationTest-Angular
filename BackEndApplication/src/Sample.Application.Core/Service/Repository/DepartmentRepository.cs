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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ILogger<DepartmentRepository> _logger;

        private readonly SampledbContext _sampledbContext;

        private readonly IMapper _mapper;
        public DepartmentRepository(ILogger<DepartmentRepository> logger, SampledbContext sampledbContext, IMapper mapper)
        {
            _logger = logger;
            _sampledbContext = sampledbContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Department>> GetDepartmentAsync(CancellationToken cancellationToken)
        {
            try
            {
                var departmentList = await _sampledbContext.TblDepartment.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
                return _mapper.Map<IEnumerable<TblDepartment>, IEnumerable<Department>>(departmentList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
