using Domain.Exception.Base;

namespace Domain.Exception;

public class PostNotFoundException : NotFoundException
{
    public PostNotFoundException(string message = "Post not found !") : base(message)
    {
        
    }
}