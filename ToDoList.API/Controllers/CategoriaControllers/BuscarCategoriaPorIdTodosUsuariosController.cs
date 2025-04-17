using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria - Admin")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Admin}")]
[ApiController]
public class BuscarCategoriaPorIdTodosUsuariosController : ControllerBase
{
    private readonly BuscarCategoriaPorIdTodosUsuariosUseCase _buscarCategoria;

    public BuscarCategoriaPorIdTodosUsuariosController(BuscarCategoriaPorIdTodosUsuariosUseCase buscarCategoria)
    {
        _buscarCategoria = buscarCategoria;
    }

    [HttpGet]
    public async Task<IActionResult> Execute(Guid categoriaId)
    {
        var categoria = await _buscarCategoria.Execute(categoriaId);

        if (categoria.IsFailure) return BadRequest(categoria.Error);

        return Ok(categoria.Value);
    }
}
