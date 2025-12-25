using System;
using System.Collections.Generic;
using System.Text;

namespace Taafi.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string mailTo, string subject, string body);
    }
}
