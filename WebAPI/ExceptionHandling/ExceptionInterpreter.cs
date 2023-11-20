using System.Net;
using Domain.Exception.Base;

namespace WebAPI.ExceptionHandling;

public class ExceptionInterpreter
{
    public ProblemResponse Interpret(Exception exception)
    {
        ProblemResponse response = new ProblemResponse();
        switch (exception)
        {
            case NotFoundException:
                response.Message = exception.Message;
                response.StatusCode = HttpStatusCode.NotFound; 
                break;
            default:
                response.Message = "Not implemented exception";
                response.StatusCode = HttpStatusCode.InternalServerError;
                break;
        }

        return response;
    }
}