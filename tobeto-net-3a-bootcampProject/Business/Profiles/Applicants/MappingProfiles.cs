using AutoMapper;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Entities.Concretes;

namespace Business.Profiles.Applicants
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Applicant, AddApplicantRequest>().ReverseMap();
            CreateMap<Applicant, AddApplicantResponse>().ReverseMap();

            CreateMap<Applicant, UpdateApplicantRequest>().ReverseMap();
            CreateMap<Applicant, UpdateApplicantResponse>().ReverseMap();

            CreateMap<Applicant, DeleteApplicantResponse>().ReverseMap();

            CreateMap<Applicant, GetApplicantByIdResponse>().ReverseMap();
            CreateMap<Applicant, GetAllApplicantResponse>().ReverseMap();
        }
    }
}
