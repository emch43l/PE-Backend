using System.Net;
using Domain.Exception.Base;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.ExceptionHandling;

public class ExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is ExceptionBase)
        {
            ExceptionInterpreter interpreter = new ExceptionInterpreter();
            ProblemResponse response = interpreter.Interpret(context.Exception);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                return;
            
            context.HttpContext.Response.StatusCode = (int)response.StatusCode;
            context.HttpContext.Response.WriteAsJsonAsync(response);
            context.ExceptionHandled = true;
        }
    }
}