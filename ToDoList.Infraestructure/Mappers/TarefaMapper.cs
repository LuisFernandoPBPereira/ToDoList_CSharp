using ToDoList.Domain.Builders;
using ToDoList.Domain.Entities;
using ToDoList.Infraestructure.Entities;

namespace ToDoList.Infraestructure.Mappers;

public static class TarefaMapper
{
    public static Tarefa ToDomain(TarefaEntity tarefaEntity)
    {
        var tarefaBuilder = new TarefaBuilder();

        return tarefaBuilder.ComId(tarefaEntity.Id)
                            .ComTitulo(tarefaEntity.Titulo)
                            .ComDescricao(tarefaEntity.Descricao)
                            .ComDataDeCriacao(tarefaEntity.DataCriacao)
                            .ComDataDeVencimento(tarefaEntity.DataVencimento)
                            .ComPrioridade(tarefaEntity.Prioridade)
                            .ComStatus(tarefaEntity.Status)
                            .ComUsuarioId(tarefaEntity.UsuarioId)
                            .Build();
    }

    public static TarefaEntity ToEntity(Tarefa tarefa)
    {
        return new TarefaEntity
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            DataCriacao = tarefa.DataCriacao,
            DataVencimento = tarefa.DataVencimento,
            Prioridade = tarefa.Prioridade,
            Status = tarefa.Status,
            UsuarioId = tarefa.UsuarioId,
        };
    }
}
