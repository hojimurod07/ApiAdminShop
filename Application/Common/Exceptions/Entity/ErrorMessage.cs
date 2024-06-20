namespace Application.Common.Exceptions.Entity;

public class ErrorMessage
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}