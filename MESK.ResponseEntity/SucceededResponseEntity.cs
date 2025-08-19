using System.Net;

namespace MESK.ResponseEntity;

public sealed class SucceededResponseEntity<T> : ResponseEntity<T>
{
    internal SucceededResponseEntity() : base(true,  HttpStatusCode.OK) { }
    
    public SucceededResponseEntity<T> WithData(T data)
    {
        Data = data;
        return this;
    }
}