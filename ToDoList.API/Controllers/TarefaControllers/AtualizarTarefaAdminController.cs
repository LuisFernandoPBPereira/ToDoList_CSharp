using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.TarefaDTOs;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa - Admin")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Admin}")]
[ApiController]
public class AtualizarTarefaAdminController : ControllerBase
{
    private readonly AtualizarTarefaAdminUseCase _atualizarTarefaAdmin;

    public AtualizarTarefaAdminController(AtualizarTarefaAdminUseCase atualizarTarefaAdmin)
    {
        _atualizarTarefaAdmin = atualizarTarefaAdmin;
    }

    [HttpPut]
    public async Task<IActionResult> Execute([FromBody] AtualizarTarefaDto tarefaDto)
    {
        var result = await _atualizarTarefaAdmin.Execute(tarefaDto);

        if (result.IsFailure) return BadRequest(result.Error);

        return NoContent();
    }
}
