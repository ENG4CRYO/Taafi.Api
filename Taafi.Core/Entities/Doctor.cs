public class Doctor
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Bio { get; set; } = default!;
    public Specialty Specialty { get; set; } = new Specialty();
    public string SpecialtyId { get; set; } = default!;
    public string Location { get; set; } = default!;
    public Decimal Rate { get; set; } = default!;   
    public int ExperienceYears { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public bool IsActive { get; set; } = default!;

    public ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}

