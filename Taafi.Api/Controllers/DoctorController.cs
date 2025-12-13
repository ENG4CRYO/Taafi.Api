using Microsoft.AspNetCore.Mvc;
using Taafi.Application.Dtos;
using Taafi.Application.Services;

namespace Taafi.Api.Controllers
{
    [ApiController]
    [Route("taafi/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<DoctorDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDoctors(string? search, string? specialtyId)
        {
            return Ok(await _service.GetDoctorsAsync(search, specialtyId));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DoctorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetDoctorByIdAsync(id);

            if (result == null)
            {
                return NotFound(new { message = "Doctor not found" });
            }

            return Ok(result);
        }
    }
}
