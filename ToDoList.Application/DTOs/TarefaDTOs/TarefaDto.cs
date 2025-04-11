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
        return new Tarefa(titulo, descricao, dataCriacao, dataVencimento, prioridade, status);
    }
}