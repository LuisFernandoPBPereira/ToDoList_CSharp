using Azure.Core;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ToDoList.Infraestructure.Middlewares;

public class JwtValidationClaimMiddleware
{
    private readonly RequestDelegate _next;

    public JwtValidationClaimMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var authHeader = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(authHeader);
        var usuarioIdToken = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var conversaoBemSucedida = Guid.TryParse(usuarioIdToken, out Guid usuarioId);

        if (!conversaoBemSucedida)
        {
            context.Response.StatusCode = 401;
            return;
        }

        context.Items["UsuarioId"] = usuarioId;

        await _next(context);
    }
}
