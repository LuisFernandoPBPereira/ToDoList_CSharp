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
public class RemoverTarefaController : ControllerBase
{
    private readonly RemoverTarefaUseCase _removerTarefa;

    public RemoverTarefaController(RemoverTarefaUseCase removerTarefa)
    {
        _removerTarefa = removerTarefa;
    }

    [HttpDelete]
    public async Task<IActionResult> Execute([FromBody] Guid tarefaId)
    {
        var usuarioId = HttpContext.RecuperaIdUsuarioLogado();

        var result = await _removerTarefa.Execute(usuarioId, tarefaId);

        if (result.IsFailure && result.Error == UsuarioErrors.UsuarioProibidoDeRealizarAcao)
        {
            return Forbid();
        }

        if (result.IsFailure) return BadRequest(result.Error);

        return NoContent();
    }
}
