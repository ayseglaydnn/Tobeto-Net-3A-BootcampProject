using AutoMapper;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Business.Responses.Blacklists;
using Entities.Concretes;

namespace Business.Profiles.Applications
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Application, CreateApplicationRequest>().ReverseMap();
            CreateMap<Application, CreateApplicationResponse>().ReverseMap();

            CreateMap<Application, UpdateApplicationRequest>().ReverseMap();
            CreateMap<Application, UpdateApplicationResponse>().ReverseMap();

            CreateMap<Application, DeleteApplicationResponse>().ReverseMap();

            CreateMap<Application, GetByIdApplicationResponse>().ReverseMap();
            CreateMap<Application, GetAllApplicationResponse>().ReverseMap();
        }
    }
}
