using System.Net;
using Domain.Exception.Base;
using Microsoft.AspNetCore.Diagnostics;

namespace WebAPI.ExceptionHandling;

public class ExceptionHandlerMiddleware : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ExceptionBase)
            return false;
        
        ExceptionInterpreter interpreter = new ExceptionInterpreter();
        ProblemResponse response = interpreter.Interpret((ExceptionBase)exception);

        if (response.StatusCode == HttpStatusCode.InternalServerError)
            return false;
            
        httpContext.Response.StatusCode = (int)response.StatusCode;
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;

    }
}