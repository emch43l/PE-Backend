using Domain.Model.Generic;

namespace ApplicationCore.Service;

public class AuthResult
{
    public string Token { get; set; }
    
    public Guid? UserId { get; set; }
    
}