using ToDoList.Common;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class RemoverTarefaUseCase
{
    private readonly ITarefaRepository _repository;

    public RemoverTarefaUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid usuarioId, Guid tarefaId)
    {
        var tarefa = await _repository.BuscarTarefa(tarefaId);

        if (tarefa.UsuarioId != usuarioId) return Result.Failure(UsuarioErrors.UsuarioProibidoDeRealizarAcao);

        await _repository.RemoverTarefa(tarefaId);

        return Result.Success();
    }
}
