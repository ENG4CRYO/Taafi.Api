public class Notification
{
    public string Id { get; set; } = default!;
    public ApplicationUser User { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = default!;
    

}

