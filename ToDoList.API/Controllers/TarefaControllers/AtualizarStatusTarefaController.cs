using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs.TarefaDTOs;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Domain.Errors.Usuario;

namespace ToDoList.Controllers.TarefaControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarStatusTarefaController : ControllerBase
    {
        private readonly AtualizarStatusUseCase _atualizarStatus;

        public AtualizarStatusTarefaController(AtualizarStatusUseCase atualizarStatus)
        {
            _atualizarStatus = atualizarStatus;
        }

        [HttpPatch]
        public async Task<IActionResult> Execute([FromBody] AtualizarStatusTarefaDto atualizarStatusDto)
        {
            var usuarioId = HttpContext.RecuperaIdUsuarioLogado();

            var result = await _atualizarStatus.Execute(usuarioId, atualizarStatusDto.tarefaId, atualizarStatusDto.status);

            if (result.IsFailure && result.Error == UsuarioErrors.UsuarioProibidoDeRealizarAcao)
            {
                return Forbid();
            }

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}
