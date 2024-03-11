using Business.Abstracts;
using Business.Dtos.Applicant;
using Business.Requests.Applicants;
using Core.Utilities.Results;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : BaseController
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(ApplicantRegisterDto applicantRegisterDto)
        {
            var result = await _applicantService.Register(applicantRegisterDto);
            return HandleDataResult(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _applicantService.Delete(new DeleteApplicantRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _applicantService.GetAll();
            return HandleDataResult(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _applicantService.GetById(new GetApplicantByIdRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateApplicantRequest request)
        {
            request.Id = id;
            var result = _applicantService.Update(request);
            return HandleDataResult(result);
        }

    }
}
