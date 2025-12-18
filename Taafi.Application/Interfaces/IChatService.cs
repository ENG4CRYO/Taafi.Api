using System;
using System.Collections.Generic;
using System.Text;

public interface IChatService
{
   
    Task<ServiceResponse<ChatMessageDto>> SendMessageAsync(SendMessageDto dto, string patientId);

 
    Task<ServiceResponse<List<ChatMessageDto>>> GetChatHistoryAsync(string patientId, string doctorId);
}
