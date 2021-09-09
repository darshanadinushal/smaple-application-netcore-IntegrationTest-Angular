using AutoMapper;
using Sample.Application.Core.Service.DBModel;
using Sample.Application.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Application.Core.MapperProfile
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            this.CreateMap<Employee, TblEmployee>()
                .ForMember(x=>x.Department, x=>x.Ignore())
                .ReverseMap()
                .ForMember(x => x.DepartmentName  , x => x.MapFrom(z=>z.Department.Name));

            this.CreateMap<Department, TblDepartment>().ReverseMap();
        }
    }
}
