using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return result.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationService.Login(request.Email, request.Password);

        if (result.IsError && result.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: result.FirstError.Description);
        }

        return result.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
    {
        return new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token);
    }
}
