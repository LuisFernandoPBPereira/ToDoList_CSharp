using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.TarefaControllers;

[Tags("Tarefa - Admin")]
[Route("api/[controller]")]
[Authorize($"{Roles.Admin}")]
[ApiController]
public class AssociarCategoriaAdminController : ControllerBase
{
    private readonly AssociarCategoriaEmTarefaAdminUseCase _associarCategoriaEmTarefaAdmin;

    public AssociarCategoriaAdminController(AssociarCategoriaEmTarefaAdminUseCase associarCategoriaEmTarefaAdmin)
    {
        _associarCategoriaEmTarefaAdmin = associarCategoriaEmTarefaAdmin;
    }

    [HttpPost]
    public async Task<IActionResult> Execute(Guid categoriaId, Guid tarefaId)
    {
        var usuarioId = HttpContext.RecuperaIdUsuarioLogado();

        var result = await _associarCategoriaEmTarefaAdmin.Execute(categoriaId, tarefaId);

        if (result.IsFailure) return BadRequest(result.Error);

        return Ok();
    }
}
