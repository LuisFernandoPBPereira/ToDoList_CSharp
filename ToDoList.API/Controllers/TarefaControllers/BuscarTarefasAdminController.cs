using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa - Admin")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Admin}")]
[ApiController]
public class BuscarTarefasAdminController : ControllerBase
{
    private readonly BuscarTarefasTodosUsuariosUseCase _buscarTarefasTodosUsuarios;

    public BuscarTarefasAdminController(BuscarTarefasTodosUsuariosUseCase buscarTarefasTodosUsuarios)
    {
        _buscarTarefasTodosUsuarios = buscarTarefasTodosUsuarios;
    }

    [HttpGet]
    public async Task<IActionResult> Execute(int inicioPaginacao, int totalTarefas)
    {
        var tarefas = await _buscarTarefasTodosUsuarios.Execute(inicioPaginacao, totalTarefas);

        if (tarefas.IsFailure) return BadRequest(tarefas.Error);

        return Ok(tarefas.Value);
    }
}
