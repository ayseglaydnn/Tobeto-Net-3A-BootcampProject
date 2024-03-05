using AutoMapper;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Entities.Concretes;

namespace Business.Profiles.Employees
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, AddEmployeeRequest>().ReverseMap();
            CreateMap<Employee, AddEmployeeResponse>().ReverseMap();

            CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeResponse>().ReverseMap();

            CreateMap<Employee, DeleteEmployeeResponse>().ReverseMap();

            CreateMap<Employee, GetEmployeeByIdResponse>().ReverseMap();
            CreateMap<Employee, GetAllEmployeeResponse>().ReverseMap();
        }
    }
}
