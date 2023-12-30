using Infrastructure.Identity.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IMediator _mediator;
    
    public AccountController(IMediator mediator, UserManager<UserEntity> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }
}