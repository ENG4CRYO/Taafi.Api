public class CreateAppointmentDto
{
    public string DoctorId { get; set; } = default!;
    public DateTime AppointmentDate { get; set; } = default!;
    public TimeOnly AppointmentTime { get; set; } = default!;
    public string PatientNotes { get; set; } = default!;
}

