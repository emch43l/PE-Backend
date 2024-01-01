﻿using ApplicationCore.Common.Implementation.Query;
using ApplicationCore.Common.Interface;
using Domain.Common.Query;
using Domain.Common.Repository;
using Domain.Common.Specification;
using Domain.Model.Generic;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PostRepository : EntityRepositoryBase<Post>, IPostRepository
{
    public PostRepository(IApplicationDbContext context, ISpecificationHandler<Post> specificationHandler) : base(specificationHandler,context)
    {
       
    }

    
}