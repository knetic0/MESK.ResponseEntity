using System.Net;

namespace MESK.ResponseEntity;

public sealed class FailureResponseEntity<T> : ResponseEntity<T>
{
    public Dictionary<string, string>? ValidationErrors { get; private set; }
    
    internal FailureResponseEntity() : base(false, HttpStatusCode.BadRequest) { }
    
    public FailureResponseEntity<T> WithValidationErrors(Dictionary<string, string> validationErrors)
    {
        ValidationErrors = validationErrors;
        return this;
    }
}