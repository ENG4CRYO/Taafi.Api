public class AuthModel
{
    public string Message { get; set; } = default!;
    public bool IsAuthenticated { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public List<string> Roles { get; set; } = default!;
    public string Token { get; set; } = default!;
    public DateTime ExpiresOn { get; set; }
    public string RefreshToken { get; set; } = default!;
    public DateTime RefreshTokenExpiration { get; set; }
}

