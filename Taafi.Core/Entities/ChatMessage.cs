public class ChatMessage
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string PatientId { get; set; } = default!;
    public ApplicationUser Patient { get; set; } = default!;

    public string DoctorId { get; set; } = default!;
    public Doctor Doctor { get; set; } = default!;

    public string Content { get; set; } = default!;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public bool IsUserMessage { get; set; }
}
