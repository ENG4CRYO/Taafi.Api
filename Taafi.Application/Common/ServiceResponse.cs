public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;


    public static ServiceResponse<T> Error(string message)
    {
        return new ServiceResponse<T> { Success = false, Message = message };
    }
}
