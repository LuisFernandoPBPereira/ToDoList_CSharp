using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Common;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa")]
[Route("api/[controller]")]
[ApiController]
public class AssociarCategoriaController : ControllerBase
{
    private readonly AssociarCategoriaEmTarefaUseCase _associarCategoria;

    public AssociarCategoriaController(AssociarCategoriaEmTarefaUseCase associarCategoria)
    {
        _associarCategoria = associarCategoria;
    }

    [HttpPost]
    public async Task<IActionResult> Execute(Guid categoriaId, Guid tarefaId)
    {
        var result = await _associarCategoria.Execute(categoriaId, tarefaId);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok();
    }
}
