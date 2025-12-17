public interface IAppointmentService
{
    Task<ServiceResponse<List<AppointmentDto>>> GetMyAppointmentsAsync(string patientId);
    Task<ServiceResponse<AppointmentDto?>> GetAppointmentByIdAsync(string id);
    Task <ServiceResponse<AppointmentDto>> CreateAppointmentAsync(CreateAppointmentDto appointmentDto,string patientId);
    Task<ServiceResponse<bool>> CancelAppointmentAsync(string id);
}

