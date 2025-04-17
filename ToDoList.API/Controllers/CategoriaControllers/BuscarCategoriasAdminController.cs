using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria - Admin")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Admin}")]
[ApiController]
public class BuscarCategoriasAdminController : ControllerBase
{
    private readonly BuscarCategoriasAdminUseCase _buscarCategoriasTodosUsuarios;

    public BuscarCategoriasAdminController(BuscarCategoriasAdminUseCase buscarCategoriasTodosUsuarios)
    {
        _buscarCategoriasTodosUsuarios = buscarCategoriasTodosUsuarios;
    }

    [HttpGet]
    public async Task<IActionResult> Execute(int inicioPaginacao, int totalCategorias)
    {
        var categorias = await _buscarCategoriasTodosUsuarios.Execute(inicioPaginacao, totalCategorias);

        if (categorias.IsFailure) return BadRequest(categorias.Error);

        return Ok(categorias.Value);
    }
}
