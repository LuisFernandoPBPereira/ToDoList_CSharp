using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa")]
[Authorize(Roles = $"{Roles.Comum}, {Roles.Admin}")]
[Route("api/[controller]")]
[ApiController]
public class BuscarTarefasController : ControllerBase
{
    private readonly BuscarTarefasUseCase _buscarTarefasUseCase;

    public BuscarTarefasController(BuscarTarefasUseCase buscarTarefasUseCase)
    {
        _buscarTarefasUseCase = buscarTarefasUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Execute(int inicioPaginacao, int totalTarefas)
    {
        HttpContext.Items.TryGetValue("UsuarioId", out var usuarioId);
        Guid.TryParse(usuarioId?.ToString(), out Guid usuarioIdFormated);
        
        var result = await _buscarTarefasUseCase.Execute(usuarioIdFormated, inicioPaginacao, totalTarefas);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
