﻿using ApplicationCore;
using ApplicationCore.Common.Implementation.RepositoryImplementation;
using ApplicationCore.CQRS.Post.Query;
using ApplicationCore.Pagination;
using ApplicationCore.Validation;
using FluentValidation;
using Infrastructure.DB;
using Infrastructure.Identity.Entity;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDb(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(
                configuration.GetConnectionString("SqlServer") ??
                throw new ArgumentNullException(
                    configuration.GetConnectionString("SqlServer"),
                    "Could not find connection string for database !")
            )
        );
        
        return serviceCollection;
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddIdentityCore<UserEntity>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = true;
            options.Lockout.MaxFailedAccessAttempts = 3;
        }).AddRoles<UserRoleEntity>().AddEntityFrameworkStores<ApplicationDbContext>();
        
        return serviceCollection;
    }

    public static IServiceCollection ConfigureValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IValidator<GetAllPostsPaginatedQuery>, GetAllPostsPaginatedQueryValidator>();

        return serviceCollection;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IGenericPaginator<>),typeof(GenericPaginator<>));
        serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
        serviceCollection.AddScoped<IAlbumRepository, AlbumRepository>();
        serviceCollection.AddScoped<IPostRepository, PostRepository>();
        serviceCollection.AddMediatR(options =>
            options.RegisterServicesFromAssembly(typeof(EntryPoint).Assembly)
            );

        return serviceCollection;
    }
}