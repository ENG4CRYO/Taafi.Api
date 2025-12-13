using System;
using System.Collections.Generic;
using System.Text;

namespace Taafi.Application.Dtos
{
    public class DoctorDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Bio { get; set; } = default!;
        public string SpecialtyName { get; set; } = default!;
        public string Location { get; set; } = default!;
        public Decimal Rate { get; set; } = default!;
        public int ExperienceYears { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; } = default!;

    }
}
