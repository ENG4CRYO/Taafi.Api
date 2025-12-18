using System;
using System.Collections.Generic;
using System.Text;
namespace Taafi.Application.Dtos;

public class NotificationDto
{
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}
