namespace WebAPI.Response;

public class GuidResponse
{
    public Guid Id { get; set; }

    public GuidResponse(Guid id)
    {
        Id = id;
    }
}