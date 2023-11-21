using System.Net;

namespace ApplicationCore.ExceptionHandling;

public record ProblemResponse
{
    public string Message { get; set; }

    public HttpStatusCode StatusCode { get; set; }
}