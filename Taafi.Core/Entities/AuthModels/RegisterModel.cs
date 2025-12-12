using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
    [Required]
    public string FirstName { get; set; } = default!;
    [Required]
    public string LastName { get; set; } = default!;
    [Required]
    public string UserName { get; set; } = default!;
    [Required]
    public string Email { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;

}
