using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

public class AssignmentExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
{
    public AssignmentExceptionHandlerMiddleware(RequestDelegate next) : base(next)
    {
    }

    public override (HttpStatusCode code, string message) GetResponse(Exception exception)
    {
        HttpStatusCode code;
        switch (exception)
        {
            case KeyNotFoundException
                or FileNotFoundException:
                code = HttpStatusCode.NotFound;
                break;
            
            case UnauthorizedAccessException:
                code = HttpStatusCode.Unauthorized;
                break;

            case ArgumentException
                or InvalidOperationException:
                code = HttpStatusCode.BadRequest;
                break;
                
            default:
                code = HttpStatusCode.InternalServerError;
                break;
        }
        return (code, JsonSerializer.Serialize(new SimpleResponse(exception.Message)));
    }

    public class SimpleResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; }

        public SimpleResponse(string message)
        {
            Message = message;
        }
    }
}