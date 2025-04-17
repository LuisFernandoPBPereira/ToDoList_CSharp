using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria - Admin")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Admin}")]
[ApiController]
public class RemoverCategoriaAdminController : ControllerBase
{
    private readonly RemoverCategoriaAdminUseCase _removerCategoriaAdmin;

    public RemoverCategoriaAdminController(RemoverCategoriaAdminUseCase removerCategoriaAdmin)
    {
        _removerCategoriaAdmin = removerCategoriaAdmin;
    }

    [HttpDelete]
    public async Task<IActionResult> Execute(Guid categoriaId)
    {
        var result = await _removerCategoriaAdmin.Execute(categoriaId);

        if (result.IsFailure) return BadRequest(result.Error);

        return NoContent();
    }
}
