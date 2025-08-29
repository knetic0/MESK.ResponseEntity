using System.Net;

namespace MESK.ResponseEntity;

public sealed class FailureResponseEntity<T> : ResponseEntity<T>
{
    internal FailureResponseEntity() : base(false, HttpStatusCode.BadRequest) { }
    
    public FailureResponseEntity<T> WithValidationErrors(Dictionary<string, string> validationErrors)
    {
        ValidationErrors = validationErrors;
        return this;
    }
}