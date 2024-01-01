using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.JWT;

public static class JwtEventsConfiguration
{
    public static readonly Func<AuthenticationFailedContext, Task> OnAuthenticationFailedEventBehaviour = 
        new Func<AuthenticationFailedContext, Task>(context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenException))
            {
                context.Response.Headers["Token-expired"] = "true";
            }

            return Task.CompletedTask;   
        });

    public static readonly Func<JwtBearerChallengeContext, Task> OnChallengeEventBehaviour =
        new Func<JwtBearerChallengeContext, Task>(context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            
            return context.Response.WriteAsJsonAsync(new { code = 403, message = "Not authorized" });
        });


    public static readonly Func<ForbiddenContext, Task> OnForbiddenEventBehaviour = 
        new Func<ForbiddenContext, Task>(
        context =>
        {
            context.Response.StatusCode = 403;
            context.Response.ContentType = "application/json";
            
            return context.Response.WriteAsJsonAsync(new { code = 403, message = "Not authorized" });
        });
}