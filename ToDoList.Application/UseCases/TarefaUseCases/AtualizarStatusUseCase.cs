using ToDoList.Common;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class AtualizarStatusUseCase
{
    private readonly ITarefaRepository _repository;

    public AtualizarStatusUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid tarefaId, Status status)
    {
        await _repository.AtualizarStatusTarefa(tarefaId, status);

        return Result.Success();
    }
}
