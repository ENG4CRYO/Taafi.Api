public class DoctorScheduleDto
{
    public string DayOfWeek { get; set; } = default!;
    public string StartTime { get; set; } = default!;
    public string EndTime { get; set; } = default!;
    public bool IsAvailable { get; set; }
}

