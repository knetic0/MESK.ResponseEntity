using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MESK.ResponseEntity;

public class ResponseEntity<T>
{
    public bool IsSuccess { get; private set; }

    public string? Message { get; private set; }
    
    public T? Data { get; private set; }
    
    public int StatusCode { get; private set; }
    
    [JsonConstructor]
    public ResponseEntity() { }

    protected ResponseEntity(bool isSuccess, HttpStatusCode statusCode)
    {
        IsSuccess = isSuccess;
        StatusCode = (int)statusCode;
    }

    public ResponseEntity<T> WithMessage(string message)
    {
        Message = message;
        return this;
    }
    
    public ResponseEntity<T> WithData(T data)
    {
        Data = data;
        return this;
    }

    public ResponseEntity<T> WithStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = (int)statusCode;
        return this;
    }

    public static SucceededResponseEntity<T> Succeeded()
        => new();

    public static FailureResponseEntity<T> Failure()
        => new();
    
    public override string ToString()
        => JsonSerializer.Serialize(this);
}