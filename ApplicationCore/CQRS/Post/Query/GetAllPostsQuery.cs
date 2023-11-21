﻿using ApplicationCore.Common.Implementation.EntityImplementation;
using MediatR;

namespace ApplicationCore.CQRS.Post.Query;

public class GetAllPostsQuery : IRequest<List<PostEntity>>
{
    
}