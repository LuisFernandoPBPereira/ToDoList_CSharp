using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Services;

namespace ToDoList.Controllers.LoginControllers;

[Tags("Login")]
[Route("api/[controller]")]
[AllowAnonymous]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public LoginController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    public async Task<IActionResult> Execute(string email, string senha)
    {
        var token = await _authenticationService.Login(email, senha);

        return Ok(token);
    }
}
