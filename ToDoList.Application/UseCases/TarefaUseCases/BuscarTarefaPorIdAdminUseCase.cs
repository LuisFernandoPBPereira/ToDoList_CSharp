using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class BuscarTarefaPorIdAdminUseCase
{
    private readonly ITarefaRepository _repository;

    public BuscarTarefaPorIdAdminUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Tarefa>> Execute(Guid tarefaId)
    {
        var tarefa = await _repository.BuscarTarefaPorId(tarefaId);

        return Result.Success(tarefa);
    }
}
