using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class AtualizarTarefaUseCase
{
    private readonly ITarefaRepository _repository;

    public AtualizarTarefaUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid tarefaId, Tarefa tarefa)
    {
        await _repository.AtualizarTarefa(tarefaId, tarefa);

        return Result.Success();
    }
}
