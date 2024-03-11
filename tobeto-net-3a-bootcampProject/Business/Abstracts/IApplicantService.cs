using Business.Dtos.Applicant;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;


namespace Business.Abstracts
{
    public interface IApplicantService
    {
        Task<DataResult<AccessToken>> Register(ApplicantRegisterDto applicantRegisterDto);
        public IDataResult<UpdateApplicantResponse> Update(UpdateApplicantRequest request);
        public IDataResult<DeleteApplicantResponse> Delete(DeleteApplicantRequest request);
        public IDataResult<List<GetAllApplicantResponse>> GetAll();
        public IDataResult<GetApplicantByIdResponse> GetById(GetApplicantByIdRequest request);

    }
}
