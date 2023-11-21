using System.Net;
using Domain.Exception;
using Domain.Exception.Base;

namespace ApplicationCore.ExceptionHandling;

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
            case PaginatorException:
                response.Message = exception.Message;
                response.StatusCode = HttpStatusCode.BadRequest;
                break;
            default:
                response.Message = "An error occured !";
                response.StatusCode = HttpStatusCode.InternalServerError;
                break;
        }

        return response;
    }
}