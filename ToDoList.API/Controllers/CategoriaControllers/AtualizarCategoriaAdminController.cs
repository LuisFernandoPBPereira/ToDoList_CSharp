using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.CategoriaDTOs;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria - Admin")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Admin}")]
[ApiController]
public class AtualizarCategoriaAdminController : ControllerBase
{
    private readonly AtualizarCategoriaAdminUseCase _atualizarCategoriaAdmin;

    public AtualizarCategoriaAdminController(AtualizarCategoriaAdminUseCase atualizarCategoriaAdmin)
    {
        _atualizarCategoriaAdmin = atualizarCategoriaAdmin;
    }

    [HttpPut]
    public async Task<IActionResult> Execute(AtualizarCategoriaDto categoriaDto)
    {
        var result = await _atualizarCategoriaAdmin.Execute(categoriaDto);

        if (result.IsFailure) return BadRequest(result.Error);

        return NoContent();
    }
}
