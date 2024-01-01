using ApplicationCore.Common.Interface;
using Domain.Common.Repository;
using Domain.Common.Specification;
using Domain.Model.Generic;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class AlbumRepository : EntityRepositoryBase<Album>, IAlbumRepository
{
    public AlbumRepository(IApplicationDbContext context, ISpecificationHandler<Album> specificationHandler) : base(specificationHandler,context)
    {
        
    }

    
}