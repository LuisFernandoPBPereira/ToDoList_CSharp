using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities;

public class Tarefa
{
    public Guid Id { get; private set; }
    public string? Descricao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataVencimento { get; private set; }
    public Prioridade Prioridade { get; private set; }
    public Status Status { get; private set; }
    public Guid UsuarioId { get; private set; }
}
