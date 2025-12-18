using System;
using System.Collections.Generic;
using System.Text;

public interface IGeminiService
{
    Task<string> GenerateDoctorReplyAsync(string message, string doctorName, string specialty);
}
