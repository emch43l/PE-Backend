using Domain.Common.Specification.Base;
using Domain.Enum;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.PostSpecification;

public class PrivatePostSpecification : SpecificationBase<Post>
{
    public PrivatePostSpecification()
    {
        AddCriteria(p => p.Status == StatusEnum.Visible || p.Status == StatusEnum.Hidden);
    }
}