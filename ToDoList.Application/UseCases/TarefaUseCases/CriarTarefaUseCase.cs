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

    public async Task<Result> Execute(CriarTarefaDto tarefaDto)
    {
        var tarefa = Tarefa.Criar(Guid.NewGuid(), tarefaDto.titulo, tarefaDto.descricao, tarefaDto.dataCriacao, tarefaDto.dataVencimento, tarefaDto.prioridade, tarefaDto.status, tarefaDto.usuarioId);
        await _tarefaRepository.CriarTarefa(tarefa.Value);

        return Result.Success();
    }
}
