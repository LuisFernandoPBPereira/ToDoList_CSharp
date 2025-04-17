using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Comum}, {Roles.Admin}")]
[ApiController]
public class AssociarCategoriaController : ControllerBase
{
    private readonly AssociarCategoriaEmTarefaUseCase _associarCategoria;

    public AssociarCategoriaController(AssociarCategoriaEmTarefaUseCase associarCategoria)
    {
        _associarCategoria = associarCategoria;
    }

    [HttpPost]
    public async Task<IActionResult> Execute(Guid categoriaId, Guid tarefaId)
    {
        var usuarioId = HttpContext.RecuperaIdUsuarioLogado();

        var result = await _associarCategoria.Execute(usuarioId, categoriaId, tarefaId);

        if (result.IsFailure && result.Error == UsuarioErrors.UsuarioProibidoDeRealizarAcao)
        {
            return Forbid();
        }

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok();
    }
}
