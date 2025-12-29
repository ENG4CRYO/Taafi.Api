
using Taafi.Application.Dtos;

public interface IAuthService
{
    Task<AuthModel> RegisterAsync(RegisterModel model);
    Task<AuthModel> GetTokenAsync(TokenRequestModel model);
    Task<AuthModel> LoginWithGoogleAsync(string googleIdToken);
    Task<AuthModel> RefreshTokenAsync(string token, string refreshToken);

    Task<AuthModel> UpdateUserProfileAsync(string id, UpdateUserProfileDto userDto);
}

