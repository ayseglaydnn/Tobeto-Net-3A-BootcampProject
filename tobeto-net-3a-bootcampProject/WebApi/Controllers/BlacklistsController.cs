using Business.Abstracts;
using Business.Requests.Blacklists;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistsController : BaseController
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistsController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CreateBlacklistRequest request)
        {
            return HandleDataResult(await _blacklistService.AddAsync(request));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return HandleDataResult(await _blacklistService.DeleteAsync(new DeleteBlacklistRequest { Id = id }));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _blacklistService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return HandleDataResult(await _blacklistService.GetByIdAsync(new GetByIdBlacklistRequest { Id = id }));
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateBlacklistRequest request)
        {
            request.Id = id;
            return HandleDataResult(await _blacklistService.UpdateAsync(request));
        }
    }
}
