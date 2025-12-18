using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taafi.Application.Dtos;
using Taafi.Application.Interfaces;

namespace Taafi.Api.Controllers;

[Authorize] 
[ApiController]
[Route("taafi/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }


    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageDto dto)
    {
        
        var patientId = User.FindFirstValue("uid");

        var result = await _chatService.SendMessageAsync(dto, patientId!);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }


    [HttpGet("{doctorId}")]
    public async Task<IActionResult> GetChatHistory(string doctorId)
    {
        var patientId = User.FindFirstValue("uid");

        var result = await _chatService.GetChatHistoryAsync(patientId!, doctorId);

        return Ok(result);
    }
}