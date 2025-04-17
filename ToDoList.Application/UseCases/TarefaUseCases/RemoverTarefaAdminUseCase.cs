using ToDoList.Common;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class RemoverTarefaAdminUseCase
{
    private readonly ITarefaRepository _repository;

    public RemoverTarefaAdminUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid tarefaId)
    {
        await _repository.RemoverTarefa(tarefaId);

        return Result.Success();
    }
}
