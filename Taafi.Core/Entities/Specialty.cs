public class Specialty
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string IconUrl { get; set; } = default!;
    public ICollection<Doctor> Doctors { get; set; } = default!;
}

