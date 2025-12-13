using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{    public string FullName{ get; set; } = default!;
    public string Governorate{ get; set; } = default!;
    public int Age { get; set; } = default!;
    public List<RefreshToken>? RefreshTokens { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}

