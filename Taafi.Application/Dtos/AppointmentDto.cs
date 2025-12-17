public class AppointmentDto
{
    public string Id { get; set; } = default!;
    public string PatientId { get; set; } = default!;
    public string DoctorId { get; set; } = default!;
    public DateTime AppointmentDate { get; set; } = default!;
    public TimeOnly AppointmentTime { get; set; } = default!;
    public int QueueNumber { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string PatientNotes { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = default!;
    public bool IsActive { get; set; } = default!;
    public string DoctorName { get; internal set; } = default!;
    public string DoctorImage { get; internal set; } = default!;
    public string SpecialtyName { get; internal set; } = default!;
}

