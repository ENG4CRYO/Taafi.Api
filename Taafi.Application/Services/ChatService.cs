using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Taafi.Application.Interfaces;

public class ChatService : IChatService
{
    private readonly IAppDbContext _context;
    private readonly IGeminiService _geminiService;
    private readonly IMapper _mapper;

    public ChatService(IAppDbContext context, IGeminiService geminiService, IMapper mapper)
    {
        _context = context;
        _geminiService = geminiService;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<ChatMessageDto>> SendMessageAsync(SendMessageDto dto, string patientId)
    {
        var doctor = await _context.Doctors
            .Include(d => d.Specialty)
            .FirstOrDefaultAsync(d => d.Id == dto.DoctorId);

        if (doctor == null)
            return ServiceResponse<ChatMessageDto>.Error("الطبيب غير موجود");

        var userMessage = new ChatMessage
        {
            PatientId = patientId,
            DoctorId = dto.DoctorId,
            Content = dto.Content,
            IsUserMessage = true,
            Timestamp = DateTime.UtcNow
        };

        _context.ChatMessages.Add(userMessage);
        await _context.SaveChangesAsync(CancellationToken.None);


        var aiReplyContent = await _geminiService.GenerateDoctorReplyAsync(
            dto.Content,
            doctor.Name,
            doctor.Specialty.Name
        );

        var aiMessage = new ChatMessage
        {
            PatientId = patientId,
            DoctorId = dto.DoctorId,
            Content = aiReplyContent,
            IsUserMessage = false, 
            Timestamp = DateTime.UtcNow
        };

        _context.ChatMessages.Add(aiMessage);
        await _context.SaveChangesAsync(CancellationToken.None);

 
        return new ServiceResponse<ChatMessageDto>
        {
            Data = _mapper.Map<ChatMessageDto>(aiMessage),
            Message = "تم استلام الرد"
        };
    }

    public async Task<ServiceResponse<List<ChatMessageDto>>> GetChatHistoryAsync(string patientId, string doctorId)
    {
        var messages = await _context.ChatMessages
            .Where(m => m.PatientId == patientId && m.DoctorId == doctorId)
            .OrderBy(m => m.Timestamp) 
            .ProjectTo<ChatMessageDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new ServiceResponse<List<ChatMessageDto>> { Data = messages };
    }
}
