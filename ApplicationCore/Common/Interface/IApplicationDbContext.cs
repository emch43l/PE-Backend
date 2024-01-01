﻿using Microsoft.EntityFrameworkCore;
using File = Domain.Model.Generic.File;
using Domain.Model.Generic;

namespace ApplicationCore.Common.Interface;

public interface IApplicationDbContext
{
    public DbSet<Album> Albums { get; set; }
    
    public DbSet<AlbumRating> AlbumRatings { get; set; }
    
    public DbSet<Comment> Comments { get; set; }
    
    public DbSet<CommentReaction> CommentReactions { get; set; }
    
    public DbSet<File> Files { get; set; }
    
    public DbSet<Post> Posts { get; set; }
    
    public DbSet<PostReaction> PostReactions { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}