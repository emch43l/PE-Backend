using Domain.Common.Specification.Base;
using Domain.Enum;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.PostSpecification;

public class GetPublicPostWithUserSpecification : PublicPostSpecification
{
    public GetPublicPostWithUserSpecification(Guid id) : base()
    {
        AddIncludes(c => c.User);
        AddCriteria(p => p.Guid == id);
    }
}