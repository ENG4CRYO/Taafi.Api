using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taafi.Application.Interfaces;

namespace Taafi.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("taafi/[controller]")]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        [HttpGet("specialties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSpecialtiesAsync()
        {
            var response = await _specialityService.GetAllSpecialtiesAsync();
            return Ok(response);
        }

        [HttpGet("doctors/{specialtyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDoctorDtosAsync(string specialtyId)
        {
            var response = await _specialityService.GetDoctorDtosAsync(specialtyId);
            return Ok(response);
        }
    }
}
