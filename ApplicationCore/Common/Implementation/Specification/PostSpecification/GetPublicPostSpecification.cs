using Domain.Common.Specification.Base;
using Domain.Enum;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.PostSpecification;

public class GetPublicPostSpecification : SpecificationBase<Post>
{
    public GetPublicPostSpecification(Guid id)
    {
        AddCriteria(p => p.Guid == id);
        AddCriteria(p => p.Status == StatusEnum.Visible);
    }
}