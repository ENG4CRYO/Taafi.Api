public class Notification
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public ApplicationUser User { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    

}

