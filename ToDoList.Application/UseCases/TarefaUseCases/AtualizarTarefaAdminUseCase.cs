using ToDoList.Application.DTOs.TarefaDTOs;
using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class AtualizarTarefaAdminUseCase
{
    private readonly ITarefaRepository _repository;

    public AtualizarTarefaAdminUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(AtualizarTarefaDto tarefaDto)
    {
        var tarefa = Tarefa.Criar(tarefaDto.titulo, tarefaDto.descricao, tarefaDto.dataVencimento, tarefaDto.prioridade);

        if (tarefa.IsFailure) return Result.Failure(tarefa.Error);

        await _repository.AtualizarTarefa(tarefaDto.tarefaId, tarefa.Value);

        return Result.Success();
    }
}
