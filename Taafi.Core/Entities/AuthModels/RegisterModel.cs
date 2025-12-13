using System.ComponentModel.DataAnnotations;

public class RegisterModel
{
    [Required]
    public string FullName { get; set; } = default!;
    [Required]
    public string UserName { get; set; } = default!;
    [Required]
    public string Email { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
    [Required]
    public string Governorate { get; set; } = default!;
    [Required]
    public string PhoneNumber { get; set; } = default!;
    [Required]
    public int Age { get; set; } = default!;

}
