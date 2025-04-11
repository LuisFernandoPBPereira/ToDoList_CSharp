using ToDoList.Domain.Builders;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.DTOs.TarefaDTOs;

public record TarefaDto(string titulo,
                        string descricao,
                        DateTime dataCriacao,
                        DateTime dataVencimento,
                        Prioridade prioridade,
                        Status status)
{
    public Tarefa MapearTarefa()
    {
        var tarefaBuilder = new TarefaBuilder();
        return tarefaBuilder.ComTitulo(titulo)
                            .ComDescricao(descricao)
                            .ComDataDeCriacao(dataCriacao)
                            .ComDataDeVencimento(dataVencimento)
                            .ComPrioridade(prioridade)
                            .ComStatus(status)
                            .Build();
    }
}