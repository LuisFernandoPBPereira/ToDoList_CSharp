using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities;

public class Tarefa
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public string? Descricao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataVencimento { get; private set; }
    public Prioridade Prioridade { get; private set; }
    public Status Status { get; private set; }
    public Guid UsuarioId { get; private set; }

    private Tarefa()
    {
        
    }

    public Tarefa(Guid id, string titulo, string? descricao, DateTime dataCriacao, DateTime dataVencimento, Prioridade prioridade, Status status, Guid usuarioId)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = dataCriacao;
        DataVencimento = dataVencimento;
        Prioridade = prioridade;
        Status = status;
        UsuarioId = usuarioId;
    }
    
    public Tarefa(string titulo, string? descricao, DateTime dataCriacao, DateTime dataVencimento, Prioridade prioridade, Status status)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = dataCriacao;
        DataVencimento = dataVencimento;
        Prioridade = prioridade;
        Status = status;
    }
}
