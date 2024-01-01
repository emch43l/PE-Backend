using System.Text;
using ApplicationCore;
using ApplicationCore.Common.Implementation.Specification;
using ApplicationCore.Common.Interface;
using ApplicationCore.CQRS.Comment.Query;
using ApplicationCore.CQRS.PostOperations.Command;
using ApplicationCore.CQRS.PostOperations.Query;
using ApplicationCore.Pagination;
using ApplicationCore.Service;
using ApplicationCore.Validation;
using Domain.Common.Repository;
using Domain.Common.Specification;
using Domain.Common.Specification.Base;
using FluentValidation;
using Infrastructure.DB;
using Infrastructure.Identity;
using Infrastructure.Identity.Entity;
using Infrastructure.JWT;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
        serviceCollection.AddScoped<IIdentityService, IdentityService>();
        
        return serviceCollection;
    }

    public static IServiceCollection ConfigureSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme.
                  Enter 'Bearer' and then your token in the text input below.
                  Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = JwtBearerDefaults.AuthenticationScheme,
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "PixelEnjoyers",
            });
        });

        return serviceCollection;

    }
    
    public static IServiceCollection ConfigureCors(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
        });

        return serviceCollection;
    }

    public static IServiceCollection ConfigureJwtAuthentication(this IServiceCollection serviceCollection, JwtSettings settings)
    {
        
        serviceCollection.AddAuthorization(opt => 
        {
            opt.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
            opt.AddPolicy("Email", policy => { policy.RequireClaim("email"); });
        });
        
        serviceCollection.AddAuthentication(opt => 
        {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;

            if (settings.Secret != null)
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = settings.Issuer,
                    ValidAudience = settings.Audience,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Secret)),
                    ClockSkew = TimeSpan.FromSeconds(60)
                };
            }
                
            options.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = JwtEventsConfiguration.OnAuthenticationFailedEventBehaviour,
                OnChallenge = JwtEventsConfiguration.OnChallengeEventBehaviour,
                OnForbidden = JwtEventsConfiguration.OnForbiddenEventBehaviour
            };
        });

        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<ITokenService, TokenService>();
        serviceCollection.AddSingleton<JwtSettings>();

        return serviceCollection;
    }

    public static IServiceCollection ConfigureValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IValidator<GetAllPostsPaginatedQuery>, GetAllPostsPaginatedQueryValidator>();
        serviceCollection.AddScoped<IValidator<GetPostCommentsQuery>, GetPostCommentsQueryValidator>();
        serviceCollection.AddScoped<IValidator<CreatePostCommand>, CreatePostCommandValidator>();
        serviceCollection.AddScoped<IValidator<UpdatePostCommand>, UpdatePostCommandValidator>();

        return serviceCollection;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        serviceCollection.AddScoped(typeof(ISpecificationHandler<>),typeof(SpecificationHandler<>));
        serviceCollection.AddScoped(typeof(ISpecification<>),typeof(SpecificationBase<>));
        serviceCollection.AddScoped(typeof(IGenericPaginator),typeof(GenericPaginator));
        serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
        serviceCollection.AddScoped<IAlbumRepository, AlbumRepository>();
        serviceCollection.AddScoped<IPostRepository, PostRepository>();
        serviceCollection.AddMediatR(options =>
            options.RegisterServicesFromAssembly(typeof(EntryPoint).Assembly)
            );

        return serviceCollection;
    }
}