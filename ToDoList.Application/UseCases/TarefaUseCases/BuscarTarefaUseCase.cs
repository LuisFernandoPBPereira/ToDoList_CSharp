using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class BuscarTarefaUseCase
{
    private readonly ITarefaRepository _repository;

    public BuscarTarefaUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Tarefa>> Execute(Guid tarefaId)
    {
        var tarefa = await _repository.BuscarTarefa(tarefaId);

        return Result.Success(tarefa);
    }
}
