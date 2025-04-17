using ToDoList.Common;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class AtualizarStatusUseCase
{
    private readonly ITarefaRepository _repository;

    public AtualizarStatusUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid usuarioId, Guid tarefaId, Status status)
    {
        var tarefa = await _repository.BuscarTarefaPorId(tarefaId);

        if (tarefa.UsuarioId != usuarioId) return Result.Failure(UsuarioErrors.UsuarioProibidoDeRealizarAcao);

        await _repository.AtualizarStatusTarefa(tarefaId, status);

        return Result.Success();
    }
}
