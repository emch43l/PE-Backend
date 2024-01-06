using Domain.Common.Specification.Base;
using Domain.Enum;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.PostSpecification;

public class PublicPostSpecification : SpecificationBase<Post>
{
    public PublicPostSpecification()
    {
        AddCriteria(p => p.Status == StatusEnum.Visible);
    }
}