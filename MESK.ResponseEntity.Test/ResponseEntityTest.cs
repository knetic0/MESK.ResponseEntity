using System.Net;

namespace MESK.ResponseEntity.Test;

public class ResponseEntityTest
{
    private const string TestStringData = "Hello World!";
    private const string TestStringMessage = "This is a test message!";
    
    [Fact]
    public void Succeeded_WithOnlyInitialize()
    {
        var result = ResponseEntity<string>.Succeeded();
        
        Assert.True(result.IsSuccess);
        Assert.Null(result.Data);
        Assert.Null(result.Message);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }

    [Fact]
    public void Succeeded_WithData()
    {
        var result = ResponseEntity<string>.Succeeded()
            .WithData(TestStringData);

        Assert.True(result.IsSuccess);
        Assert.Null(result.Message);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(TestStringData, result.Data);
    }
    
    [Fact]
    public void Succeeded_WithDataAndMessage()
    {
        var result = ResponseEntity<string>.Succeeded()
            .WithData(TestStringData)
            .WithMessage(TestStringMessage);

        Assert.True(result.IsSuccess);
        Assert.Equal(TestStringMessage, result.Message);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.Equal(TestStringData, result.Data);
    }
    
    [Fact]
    public void Succeeded_WithStatusCode()
    {
        var result = ResponseEntity<string>.Succeeded()
            .WithStatusCode(HttpStatusCode.Created);

        Assert.True(result.IsSuccess);
        Assert.Null(result.Message);
        Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
        Assert.Null(result.Data);
    }
    
    [Fact]
    public void Failure_WithOnlyInitialize()
    {
        var result = ResponseEntity<string>.Failure();
        
        Assert.False(result.IsSuccess);
        Assert.Null(result.ValidationErrors);
        Assert.Null(result.Data);
        Assert.Null(result.Message);
        Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
    }
    
    [Fact]
    public void Failure_WithValidationErrors()
    {
        var validationErrors = new Dictionary<string, string>
        {
            ["Key"] = "value"
        };

        var result = ResponseEntity<string>.Failure()
            .WithValidationErrors(validationErrors);
        
        Assert.False(result.IsSuccess);
        Assert.Equal(validationErrors, result.ValidationErrors);
        Assert.Null(result.Data);
        Assert.Null(result.Message);
        Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
    }
}