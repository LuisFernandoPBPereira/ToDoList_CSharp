using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.CategoriaUseCases;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria")]

[Route("api/[controller]")]
[ApiController]
public class BuscarCategoriasController : ControllerBase
{
    public readonly BuscarCategoriasUseCase _buscarCategorias;

    public BuscarCategoriasController(BuscarCategoriasUseCase buscarCategorias)
    {
        _buscarCategorias = buscarCategorias;
    }

    [HttpGet]
    public async Task<IActionResult> Execute(int inicioPaginacao, int totalCategorias)
    {
        var categorias = await _buscarCategorias.Execute(inicioPaginacao, totalCategorias);

        if (categorias.IsFailure) return BadRequest(categorias.Error);

        return Ok(categorias.Value);
    }
}
