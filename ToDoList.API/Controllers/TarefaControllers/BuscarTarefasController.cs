using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.TarefaUseCases;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa")]
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
    public async Task<IActionResult> Execute(int pagina, int totalTarefas)
    {
        var result = await _buscarTarefasUseCase.Execute(pagina, totalTarefas);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
