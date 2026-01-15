public class UserProfileDto
{
    public string Id { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string UserName { get; set; } = default!;

    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Governorate { get; set; } = default!;
    public List<string> Roles { get; set; } = new();

    public int Age { get; set; }
    }

