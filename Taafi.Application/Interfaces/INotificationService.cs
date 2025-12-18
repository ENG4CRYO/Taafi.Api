using Taafi.Application.Dtos;

namespace Taafi.Application.Interfaces;

public interface INotificationService
{
    
    Task<ServiceResponse<List<NotificationDto>>> GetMyNotificationsAsync(string userId);
    Task<ServiceResponse<bool>> MarkAsReadAsync(string notificationId);
    Task CreateNotificationAsync(string userId, string title, string message);
}