using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Taafi.Application.Dtos;
using Taafi.Application.Interfaces;


public class NotificationService : INotificationService
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public NotificationService(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<NotificationDto>>> GetMyNotificationsAsync(string userId)
    {
        var notifications = await _context.Notifications.AsNoTracking()
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt) 
            .ProjectTo<NotificationDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new ServiceResponse<List<NotificationDto>> { Data = notifications };
    }

    public async Task<ServiceResponse<bool>> MarkAsReadAsync(string notificationId)
    {
        var notification = await _context.Notifications.FindAsync(notificationId);

        if (notification == null)
            return ServiceResponse<bool>.Error("Notification not found");

        notification.IsRead = true;
        await _context.SaveChangesAsync(CancellationToken.None);

        return new ServiceResponse<bool> { Data = true };
    }

    public async Task CreateNotificationAsync(string userId, string title, string message)
    {
        var notification = new Notification
        {
            UserId = userId,
            Title = title,
            Message = message,
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync(CancellationToken.None);
    }
}