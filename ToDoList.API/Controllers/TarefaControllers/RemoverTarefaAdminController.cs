using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa - Admin")]
[Route("api/[controller]")]
[Authorize($"{Roles.Admin}")]
[ApiController]
public class RemoverTarefaAdminController : ControllerBase
{
    private readonly RemoverTarefaAdminUseCase _removerTarefaAdmin;

    public RemoverTarefaAdminController(RemoverTarefaAdminUseCase removerTarefaAdmin)
    {
        _removerTarefaAdmin = removerTarefaAdmin;
    }

    [HttpDelete]
    public async Task<IActionResult> Execute(Guid tarefaId)
    {
        var result = await _removerTarefaAdmin.Execute(tarefaId);

        if (result.IsFailure) return BadRequest(result.Error);

        return NoContent();
    }
}
