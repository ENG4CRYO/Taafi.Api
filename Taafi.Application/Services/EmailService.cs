using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Options;
using Taafi.Application.Interfaces;

public class EmailService : IEmailService
{
    private readonly MailSettings _mailSettings;

    public EmailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(string mailTo, string subject, string body)
    {
        var email = new MimeMessage();

  
        email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.EmailFrom));

   
        email.To.Add(MailboxAddress.Parse(mailTo));

      
        email.Subject = subject;

        var builder = new BodyBuilder();
        builder.HtmlBody = body; 
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();

        try
        {

            await smtp.ConnectAsync(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);

        
            await smtp.AuthenticateAsync(_mailSettings.SmtpUser, _mailSettings.SmtpPass);

     
            await smtp.SendAsync(email);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            await smtp.DisconnectAsync(true);
        }
    }
}