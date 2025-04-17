using ToDoList.Application.DTOs.TarefaDTOs;
using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class AtualizarTarefaUseCase
{
    private readonly ITarefaRepository _repository;

    public AtualizarTarefaUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid usuarioId, AtualizarTarefaDto tarefaDto)
    {
        var tarefaParaAtualizar = await _repository.BuscarTarefaPorId(tarefaDto.tarefaId);

        if (tarefaParaAtualizar.UsuarioId != usuarioId) return Result.Failure(UsuarioErrors.UsuarioProibidoDeRealizarAcao);

        var tarefa = Tarefa.Criar(tarefaDto.titulo, tarefaDto.descricao, tarefaDto.dataVencimento, tarefaDto.prioridade);

        if (tarefa.IsFailure) return Result.Failure(tarefa.Error);

        await _repository.AtualizarTarefa(tarefaDto.tarefaId, tarefa.Value);

        return Result.Success();
    }
}
