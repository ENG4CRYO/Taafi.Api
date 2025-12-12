
public interface IAuthService
{
    Task<AuthModel> RegisterAsync(RegisterModel model);
    Task<AuthModel> GetTokenAsync(TokenRequestModel model);
    Task<AuthModel> RefreshTokenAsync(string token, string refreshToken);
}

