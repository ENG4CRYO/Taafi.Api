using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taafi.Application.Dtos;

[ApiController]
[Route("taafi/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var result = await _authService.RegisterAsync(model);

        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid payload");
        }

        if (!result.IsAuthenticated)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] TokenRequestModel model)
    {
        var result = await _authService.GetTokenAsync(model);

        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid payload");
        }

        if (!result.IsAuthenticated)
        {
            return BadRequest(result.Message);
        }


        return Ok(result);
    }

    [HttpPost("refresh-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.RefreshTokenAsync(model.Token, model.RefreshToken);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        return Ok(result);
    }


    [HttpPost("google-login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _authService.LoginWithGoogleAsync(model.IdToken);
        if (!result.IsAuthenticated)
            return BadRequest(result.Message);
        return Ok(result);
    }
    [Authorize]
    [HttpPut("update-profile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileDto dto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(dto);
        }

        var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

        var result = await _authService.UpdateUserProfileAsync(userId, dto);

        if (!result.IsAuthenticated)
            return BadRequest(result.Message);

        return Ok(result);
    }

}
