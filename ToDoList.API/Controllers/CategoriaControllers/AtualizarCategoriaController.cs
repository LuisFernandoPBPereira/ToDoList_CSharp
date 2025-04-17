using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.CategoriaDTOs;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Comum}, {Roles.Admin}")]
[ApiController]
public class AtualizarCategoriaController : ControllerBase
{
    private readonly AtualizarCategoriaUseCase _atualizarCategoria;

    public AtualizarCategoriaController(AtualizarCategoriaUseCase atualizarCategoria)
    {
        _atualizarCategoria = atualizarCategoria;
    }

    [HttpPut]
    public async Task<IActionResult> Execute([FromBody] AtualizarCategoriaDto categoriaDto)
    {
        var result = await _atualizarCategoria.Execute(categoriaDto);

        if (result.IsFailure) return BadRequest(result.Error);

        return NoContent();
    }
}
