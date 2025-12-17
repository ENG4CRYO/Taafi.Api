public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetMyAppointmentsAsync(string patientId);
    Task<AppointmentDto?> GetAppointmentByIdAsync(string id);
    Task <ServiceResponse<AppointmentDto>> CreateAppointmentAsync(CreateAppointmentDto appointmentDto,string patientId);
    Task<bool> CancelAppointmentAsync(string id);
}

