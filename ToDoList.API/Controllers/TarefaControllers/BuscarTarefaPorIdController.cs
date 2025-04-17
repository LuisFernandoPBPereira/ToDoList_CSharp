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
public class BuscarTarefaPorIdController : ControllerBase
{
    private readonly BuscarTarefaPorIdUseCase _buscarTarefaPorId;

    public BuscarTarefaPorIdController(BuscarTarefaPorIdUseCase buscarTarefaPorId)
    {
        _buscarTarefaPorId = buscarTarefaPorId;
    }

    [HttpGet]
    public async Task<IActionResult> Execute(Guid tarefaId)
    {
        var usuarioId = HttpContext.RecuperaIdUsuarioLogado();

        var result = await _buscarTarefaPorId.Execute(usuarioId, tarefaId);

        if (result.IsFailure && result.Error == UsuarioErrors.UsuarioProibidoDeRealizarAcao)
        {
            return Forbid();
        }

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
