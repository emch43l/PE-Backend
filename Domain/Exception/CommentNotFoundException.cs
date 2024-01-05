using Domain.Exception.Base;

namespace Domain.Exception;

public class CommentNotFoundException : NotFoundException
{
    public CommentNotFoundException(string message = "Comment not found !") : base(message)
    {
        
    }
}