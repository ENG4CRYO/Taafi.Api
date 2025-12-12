public class DoctorShedule
{
    public string Id { get; set; } = default!;
    public Doctor Doctor { get; set; } = default!;
    public string DoctorId { get; set; } = default!;
    public DayOfWeek DayOfWeek { get; set; } = default!;
    public TimeOnly StartTime { get; set; } = default!;
    public TimeOnly EndTime { get; set; } = default!;
    public bool IsAvailable { get; set; } = default!;
}
