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
public class CriarCategoriaController : ControllerBase
{
    private readonly CriarCategoriaUseCase _categoriaUseCase;

    public CriarCategoriaController(CriarCategoriaUseCase categoriaUseCase)
    {
        _categoriaUseCase = categoriaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Execute([FromBody] CriarCategoriaDto categoriaDto)
    {
        var result = await _categoriaUseCase.Execute(categoriaDto);

        if (result.IsFailure) return BadRequest(result.Error);

        return Created();
    }
}
