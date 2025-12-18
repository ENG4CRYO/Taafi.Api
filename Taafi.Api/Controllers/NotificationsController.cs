using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taafi.Application.Interfaces;

namespace Taafi.Api.Controllers;

[Authorize]
[ApiController]
[Route("taafi/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyNotifications()
    {
        var userId = User.FindFirstValue("uid");
        var result = await _notificationService.GetMyNotificationsAsync(userId!);
        return Ok(result);
    }

    [HttpPut("{id}/read")]
    public async Task<IActionResult> MarkAsRead(string id)
    {
        var result = await _notificationService.MarkAsReadAsync(id);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }
}