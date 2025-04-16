using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria")]
[Authorize(Roles = $"{Roles.Comum}, {Roles.Admin}")]
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
        var usuarioId = HttpContext.RecuperaIdUsuarioLogado();

        var categorias = await _buscarCategorias.Execute(usuarioId, inicioPaginacao, totalCategorias);

        if (categorias.IsFailure) return BadRequest(categorias.Error);

        return Ok(categorias.Value);
    }
}
