using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{    public string FullName{ get; set; } = default!;
    public string Governorate{ get; set; } = default!;
    public string City{ get; set; } = default!;
    public string Gender { get; set; } = default!;
    public string AvatarUrl { get; set; } = default!;
    public List<RefreshToken>? RefreshTokens { get; set; }

    public ICollection<Appoinnment> Appoinnments { get; set; } = default!;
    public ICollection<Notification> Notifications { get; set; } = default!;
}

