using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.CategoriaDTOs;
using ToDoList.Application.UseCases.CategoriaUseCases;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria")]
[Route("api/[controller]")]
[ApiController]
public class CriarCategoriaController : ControllerBase
{
    private readonly CriarCategoriaUseCase _categoriaUseCase;

    public CriarCategoriaController(CriarCategoriaUseCase categoriaUseCase)
    {
        _categoriaUseCase = categoriaUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Execute([FromForm] CriarCategoriaDto categoriaDto)
    {
        var result = await _categoriaUseCase.Execute(categoriaDto);

        if (result.IsFailure) return BadRequest(result.Error);

        return Created();
    }
}
