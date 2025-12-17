using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taafi.Application.Dtos;
using Taafi.Application.Interfaces;

namespace Taafi.Api.Controllers;

[Authorize]
[ApiController]
[Route("taafi/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("my-appointments")]
    [ProducesResponseType(typeof(List<AppointmentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMyAppointments()
    {
        var patientId = User.FindFirstValue("uid");

        var result = await _appointmentService.GetMyAppointmentsAsync(patientId!);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _appointmentService.GetAppointmentByIdAsync(id);
        if (result == null) return NotFound();

        var patientId = User.FindFirstValue("uid");
        if (result.PatientId != patientId) return Unauthorized();

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentDto dto)
    {
        var patientId = User.FindFirstValue("uid");

        var result = await _appointmentService.CreateAppointmentAsync(dto, patientId!);

        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }
        return Ok(result.Data);
    }

    [HttpPut("{id}/cancel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Cancel(string id)
    {
        var result = await _appointmentService.CancelAppointmentAsync(id);

        if (!result) return NotFound();

        return Ok(new { message = "Appointment cancelled successfully" });
    }
}