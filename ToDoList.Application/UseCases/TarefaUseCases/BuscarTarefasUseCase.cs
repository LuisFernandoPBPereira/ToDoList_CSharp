using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class BuscarTarefasUseCase
{
    private readonly ITarefaRepository _tarefaRepository;

    public BuscarTarefasUseCase(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<Result<IEnumerable<Tarefa>>> Execute(Guid usuarioId, int pagina = 0, int totalTarefas = 10)
    {
        var tarefas = await _tarefaRepository.BuscarTarefas(usuarioId, pagina, totalTarefas);

        return Result.Success(tarefas);
    }
}
