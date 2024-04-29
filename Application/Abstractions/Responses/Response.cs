namespace Application.Abstractions.Responses;

public class Response<T>(
    T data,
    int status = 200,
    string message = "")
{
    public string Message { get; set; } = message;
    public int Status { get; set; } = status;
    public T Data { get; set; } = data;
}