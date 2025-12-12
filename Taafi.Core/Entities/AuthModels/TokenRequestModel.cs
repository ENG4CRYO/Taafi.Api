using System.ComponentModel.DataAnnotations;

public class TokenRequestModel
{
    [Required]
    public string Email { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
}

