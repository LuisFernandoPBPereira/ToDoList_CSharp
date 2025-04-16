using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class BuscarTarefasTodosUsuariosUseCase
{
    private readonly ITarefaRepository _repository;

    public BuscarTarefasTodosUsuariosUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<Tarefa>>> Execute(int inicioPaginacao, int totalTarefas)
    {
        var tarefas = await _repository.BuscarTarefas(inicioPaginacao, totalTarefas);
    
        return Result.Success(tarefas);
    }
}
