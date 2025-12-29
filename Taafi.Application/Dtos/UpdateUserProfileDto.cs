using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Taafi.Application.Dtos
{
    public class UpdateUserProfileDto
    {
        [Required]
        public string FullName { get; set; } = default!;
        [Required, MinLength(11), MaxLength(11)]
        public string PhoneNumber { get; set; } = default!;
        [Required]
        public string Governorate { get; set; } = default!;
        [Required, Range(1, 120)]
        public int Age { get; set; } = default!;
    }
}
