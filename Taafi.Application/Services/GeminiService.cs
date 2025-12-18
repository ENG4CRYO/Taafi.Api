using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

public class GeminiService : IGeminiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;

    public GeminiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["Gemini:ApiKey"]!;
        _baseUrl = configuration["Gemini:BaseUrl"]!;
    }

    public async Task<string> GenerateDoctorReplyAsync(string message, string doctorName, string specialty)
    {

        var systemInstruction = $@"
            You are Dr. {doctorName}, a specialist in {specialty}.
            Answer the patient's question professionally, briefly, and kindly.
            Do not prescribe specific medications. Advise them to visit the clinic if necessary.
            Answer in the same language as the patient (Arabic or English).
        ";

 
        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = systemInstruction + "\n\nPatient: " + message }
                    }
                }
            }
        };

        var jsonContent = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json");


        var response = await _httpClient.PostAsync($"{_baseUrl}?key={_apiKey}", jsonContent);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
    
            return $"Gemini Error ({response.StatusCode}): {errorContent}";
        }

        var resultJson = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(resultJson);


        var reply = doc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();

        return reply ?? "لم أستطع فهم الرسالة.";
    }
}

