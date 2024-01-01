using Domain.Enum;

namespace Domain.Model.Generic;

public class StatusField : IEquatable<StatusEnum>
{
    public StatusEnum Status { get; set; }
    
    public string StatusName { get; set; }

    public static StatusField FromStatusEnum(StatusEnum status)
    {
        return new StatusField()
        {
            Status = status,
            StatusName = status.ToString()
        };
    }

    public bool Equals(StatusEnum other)
    {
        return Status == other;
    }
}