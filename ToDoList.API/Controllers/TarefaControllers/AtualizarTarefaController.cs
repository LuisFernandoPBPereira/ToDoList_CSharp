using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.TarefaDTOs;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Comum}, {Roles.Admin}")]
[ApiController]
public class AtualizarTarefaController : ControllerBase
{
    private readonly AtualizarTarefaUseCase _atualizarTarefa;

    public AtualizarTarefaController(AtualizarTarefaUseCase atualizarTarefa)
    {
        _atualizarTarefa = atualizarTarefa;
    }

    [HttpPut]
    public async Task<IActionResult> Execute([FromBody] AtualizarTarefaDto tarefaDto)
    {
        var usuarioId = HttpContext.RecuperaIdUsuarioLogado();

        var result = await _atualizarTarefa.Execute(usuarioId, tarefaDto);

        if (result.IsFailure && result.Error == UsuarioErrors.UsuarioProibidoDeRealizarAcao)
        {
            return Forbid();
        }

        if (result.IsFailure) return BadRequest(result.Error);

        return NoContent();
    }
}
