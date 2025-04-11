using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.TarefaDTOs;
using ToDoList.Application.UseCases.TarefaUseCases;

namespace To_do_List.Controllers.TarefaControllers;

[Tags("Tarefa")]
[Route("api/[controller]")]
[ApiController]
public class CriarTarefaController : ControllerBase
{
    private readonly CriarTarefaUseCase _criarTarefaUseCase;

    public CriarTarefaController(CriarTarefaUseCase criarTarefaUseCase)
    {
        _criarTarefaUseCase = criarTarefaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Execute([FromForm] CriarTarefaDto tarefaDto)
    {
        var result = await _criarTarefaUseCase.Execute(tarefaDto);

        if (result.IsFailure) return BadRequest(result.Error);

        return Created();
    }
}
