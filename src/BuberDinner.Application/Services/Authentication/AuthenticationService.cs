using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        var userId = Guid.NewGuid();
        
        var token = _tokenGenerator.GenerateToken(userId, "x", "y");

        return new(userId,
            "x",
            "y",
            email,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        var userId = Guid.NewGuid();
        
        var token = _tokenGenerator.GenerateToken(userId, "x", "y");

        return new(userId,
            firstName,
            lastName,
            email,
            token);
    }
}
