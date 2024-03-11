using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Applicant;
using Business.Dtos.Instructor;
using Business.Requests.Instructors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : BaseController
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(InstructorRegisterDto instructorRegisterDto)
        {
            var result = await _instructorService.Register(instructorRegisterDto);
            return HandleDataResult(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _instructorService.Delete(new DeleteInstructorRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _instructorService.GetAll();
            return HandleDataResult(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _instructorService.GetById(new GetInstructorByIdRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateInstructorRequest request)
        {
            request.Id = id;
            var result = _instructorService.Update(request);
            return HandleDataResult(result);
        }
    }
}
