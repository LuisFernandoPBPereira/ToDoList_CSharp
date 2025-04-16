using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.UsuarioDTOs;
using ToDoList.Application.UseCases.UsuarioUseCases;

namespace ToDoList.Controllers.UsuarioControllers;

[Tags("Usuário")]
[Route("api/[controller]")]
[AllowAnonymous]
[ApiController]
public class CadastrarUsuarioController : ControllerBase
{
    private readonly CadastrarUsuarioUseCase _cadastrarUsuarioUseCase;

    public CadastrarUsuarioController(CadastrarUsuarioUseCase cadastrarUsuarioUseCase)
    {
        _cadastrarUsuarioUseCase = cadastrarUsuarioUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Execute([FromBody] CriarUsuarioDto usuarioDto)
    {
        var result = await _cadastrarUsuarioUseCase.Execute(usuarioDto);

        if (result.IsFailure) return BadRequest(result.Error);

        return Created();
    }
}
