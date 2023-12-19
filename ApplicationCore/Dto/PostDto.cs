namespace ApplicationCore.Dto;

public class PostDto
{
    public CommentDto? FirstComment { get; set; }
    public UserDto User { get; set; }
    public int CommentCount { get; set; }
    public int ReactionCount { get; set; }
    public string Title { get; set; }
}