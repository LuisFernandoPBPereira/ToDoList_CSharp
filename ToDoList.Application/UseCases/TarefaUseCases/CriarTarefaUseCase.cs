using ToDoList.Application.DTOs.TarefaDTOs;
using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class CriarTarefaUseCase
{
    private readonly ITarefaRepository _tarefaRepository;

    public CriarTarefaUseCase(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<Result<Tarefa>> Execute(TarefaDto tarefaDto)
    {
        var tarefa = tarefaDto.MapearTarefa();
        await _tarefaRepository.CriarTarefa(tarefa);

        return Result.Success(tarefa);
    }
}
