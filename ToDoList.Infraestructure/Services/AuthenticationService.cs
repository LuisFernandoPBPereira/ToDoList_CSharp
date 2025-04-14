using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList.Infraestructure.Entities;
using ToDoList.Application.Services;

namespace ToDoList.Infraestructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<UsuarioIdentity> _userManager;
    private readonly IConfiguration _configuration;

    public AuthenticationService(UserManager<UsuarioIdentity> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> Login(string email, string senha)
    {
        var usuarioIdentity = await _userManager.FindByEmailAsync(email);

        if (usuarioIdentity is null) throw new Exception("Usuário e/ou senha incorretos...");
        
        var result = await _userManager.CheckPasswordAsync(usuarioIdentity, senha);

        if (result is false) throw new Exception("Usuário e/ou senha incorretos...");

        var roles = await _userManager.GetRolesAsync(usuarioIdentity);
        var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, usuarioIdentity.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        }.Union(roleClaims);

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
