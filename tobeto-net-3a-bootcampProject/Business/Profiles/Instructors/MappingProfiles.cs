using AutoMapper;
using Business.Requests.Applicants;
using Business.Requests.Instructors;
using Business.Responses.Applicants;
using Business.Responses.Instructors;
using Entities.Concretes;

namespace Business.Profiles.Instructors
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Instructor, AddInstructorRequest>().ReverseMap();
            CreateMap<Instructor, AddInstructorResponse>().ReverseMap();

            CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorResponse>().ReverseMap();

            CreateMap<Instructor, DeleteInstructorResponse>().ReverseMap();

            CreateMap<Instructor, GetInstructorByIdResponse>().ReverseMap();
            CreateMap<Instructor, GetAllInstructorResponse>().ReverseMap();
        }
    }
}
