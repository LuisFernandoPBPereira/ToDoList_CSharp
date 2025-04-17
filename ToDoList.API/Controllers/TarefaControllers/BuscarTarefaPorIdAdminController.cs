using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa - Admin")]
[Route("api/[controller]")]
[Authorize($"{Roles.Admin}")]
[ApiController]
public class BuscarTarefaPorIdAdminController : ControllerBase
{
    private readonly BuscarTarefaPorIdAdminUseCase _buscarTarefaPorIdAdmin;

    public BuscarTarefaPorIdAdminController(BuscarTarefaPorIdAdminUseCase buscarTarefaPorIdAdmin)
    {
        _buscarTarefaPorIdAdmin = buscarTarefaPorIdAdmin;
    }

    [HttpGet]
    public async Task<IActionResult> Execute(Guid tarefaId)
    {
        var result = await _buscarTarefaPorIdAdmin.Execute(tarefaId);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result);
    }
}
