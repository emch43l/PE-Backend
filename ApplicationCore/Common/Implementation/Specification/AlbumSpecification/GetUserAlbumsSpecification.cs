using Domain.Common.Specification.Base;
using Domain.Model;

namespace ApplicationCore.Common.Implementation.Specification.AlbumSpecification;

public class GetUserAlbumsSpecification : SpecificationBase<Album>
{
    public GetUserAlbumsSpecification(IUser user)
    {
        AddCriteria(a => a.User == user);
    }
}