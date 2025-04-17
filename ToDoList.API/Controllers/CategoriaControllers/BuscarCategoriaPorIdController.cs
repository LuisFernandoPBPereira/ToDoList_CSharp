using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Infraestructure;

namespace ToDoList.Controllers.CategoriaControllers;

[Tags("Categoria")]
[Route("api/[controller]")]
[Authorize(Roles = $"{Roles.Comum}, {Roles.Admin}")]
[ApiController]
public class BuscarCategoriaPorIdController : ControllerBase
{
    private readonly BuscarCategoriaPorIdUseCase _buscarCategoriaPorId;

    public BuscarCategoriaPorIdController(BuscarCategoriaPorIdUseCase buscarCategoriaPorId)
    {
        _buscarCategoriaPorId = buscarCategoriaPorId;
    }

    [HttpGet]
    public async Task<IActionResult> Execute(Guid usuarioId, Guid tarefaId)
    {
        var categoria = await _buscarCategoriaPorId.Execute(usuarioId, tarefaId);

        if (categoria.IsFailure) return BadRequest(categoria.Error);

        return Ok(categoria);
    }
}
