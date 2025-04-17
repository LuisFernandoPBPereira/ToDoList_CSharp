using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Comum}, {Roles.Admin}")]
[ApiController]
public class RemoverCategoriaController : ControllerBase
{
    private readonly RemoverCategoriaUseCase _removerCategoria;

    public RemoverCategoriaController(RemoverCategoriaUseCase removerCategoria)
    {
        _removerCategoria = removerCategoria;
    }

    public async Task<IActionResult> Execute(Guid usuarioId, Guid categoria)
    {
        var result = await _removerCategoria.Execute(usuarioId, categoria);

        if (result.IsFailure && result.Error == UsuarioErrors.UsuarioProibidoDeRealizarAcao)
        {
            return Forbid();
        }

        if (result.IsFailure) return BadRequest(result.Error);

        return NoContent();
    }
}
