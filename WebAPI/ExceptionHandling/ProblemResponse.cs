using System.Net;

namespace WebAPI.ExceptionHandling;

public record ProblemResponse
{
    public string Message { get; set; }

    public HttpStatusCode StatusCode { get; set; }
}