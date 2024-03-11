using Business.Dtos.Instructor;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;


namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<DataResult<AccessToken>> Register(InstructorRegisterDto instructorRegisterDto);
        public IDataResult<UpdateInstructorResponse> Update(UpdateInstructorRequest request);
        public IDataResult<DeleteInstructorResponse> Delete(DeleteInstructorRequest request);
        public IDataResult<List<GetAllInstructorResponse>> GetAll();
        public IDataResult<GetInstructorByIdResponse> GetById(GetInstructorByIdRequest request);
    }
}
