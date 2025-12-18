using System;
using System.Collections.Generic;
using System.Text;
public class ChatMessageDto
{
    public string Id { get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateTime Timestamp { get; set; }
    public bool IsUserMessage { get; set; } 
}
