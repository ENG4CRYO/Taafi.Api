public class MailSettings
{
    public string EmailFrom { get; set; } = default!;
    public string SmtpHost { get; set; } = default!;
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; } = default!;
    public string SmtpPass { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
}