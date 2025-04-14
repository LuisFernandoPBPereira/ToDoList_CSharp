using ToDoList.Common;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class RemoverTarefaUseCase
{
    private readonly ITarefaRepository _repository;

    public RemoverTarefaUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid tarefaId)
    {
        await _repository.RemoverTarefa(tarefaId);

        return Result.Success();
    }
}
