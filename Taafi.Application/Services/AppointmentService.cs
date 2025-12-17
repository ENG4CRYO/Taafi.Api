using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Taafi.Application.Interfaces;

public class AppointmentService : IAppointmentService
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;    
    public AppointmentService(IMapper mapper, IAppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<bool> CancelAppointmentAsync(string id)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);

        if (appointment == null)
        {
            return false;
        }
        appointment.Status = AppointmentStatus.Cancelled;
        await _context.SaveChangesAsync(CancellationToken.None);
        return true;
    }

    public async Task<ServiceResponse<AppointmentDto>> CreateAppointmentAsync(CreateAppointmentDto appointmentDto, string patientId)
    {

        var response = new ServiceResponse<AppointmentDto>();

       
        var doctorExists = await _context.Doctors.AnyAsync(d => d.Id == appointmentDto.DoctorId);
        if (!doctorExists)
        {
       
            return ServiceResponse<AppointmentDto>.Error("Doctor is not exists");
        }

        var dayOfWeek = appointmentDto.AppointmentDate.DayOfWeek;
        var schedule = await _context.DoctorSchedules
            .FirstOrDefaultAsync(s => s.DoctorId == appointmentDto.DoctorId && s.DayOfWeek == dayOfWeek);

        if (schedule == null || !schedule.IsAvailable)
        {
            return ServiceResponse<AppointmentDto>.Error("The doctor is unavailable today");
        }

        var appointment = new Appointment
        {
            Id = Guid.NewGuid().ToString(),
            PatientId = patientId,
            DoctorId = appointmentDto.DoctorId,
            AppointmentDate = appointmentDto.AppointmentDate,
            AppointmentTime = appointmentDto.AppointmentTime,
            PatientNotes = appointmentDto.PatientNotes ?? "",
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            Status = AppointmentStatus.Confirmed,
        };

        int queueNumber = await _context.Appointments
            .CountAsync(a => a.DoctorId == appointment.DoctorId &&
                             a.AppointmentDate.Date == appointment.AppointmentDate.Date &&
                             a.Status != AppointmentStatus.Cancelled) + 1;

        appointment.QueueNumber = queueNumber;

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync(CancellationToken.None);


        response.Data = _mapper.Map<AppointmentDto>(appointment);
        response.Message = "Your reservation has been completed successfully";
        return response;
    }

    public async Task<AppointmentDto?> GetAppointmentByIdAsync(string id)
    {
        return await _context.Appointments
            .Where(a => a.Id == id)
            .ProjectTo<AppointmentDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<List<AppointmentDto>> GetMyAppointmentsAsync(string patientId)
    {
        
        return await _context.Appointments
            .Where(a => a.PatientId == patientId)
            .OrderByDescending(a => a.AppointmentDate) 
            .ProjectTo<AppointmentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}

