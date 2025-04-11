using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Builders;

public class TarefaBuilder
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public string? Descricao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataVencimento { get; private set; }
    public Prioridade Prioridade { get; private set; }
    public Status Status { get; private set; }
    public Guid UsuarioId { get; private set; }

    public TarefaBuilder ComId(Guid id)
    {
        Id = id;
        return this;
    }

    public TarefaBuilder ComTitulo(string titulo)
    {
        Titulo = titulo;
        return this;
    }
    
    public TarefaBuilder ComDescricao(string descricao)
    {
        Descricao = descricao;
        return this;
    }

    public TarefaBuilder ComDataDeCriacao(DateTime dataCriacao)
    {
        DataCriacao = dataCriacao;
        return this;
    }
    
    public TarefaBuilder ComDataDeVencimento(DateTime dataVencimento)
    {
        DataVencimento = dataVencimento;
        return this;
    }

    public TarefaBuilder ComPrioridade(Prioridade prioridade)
    {
        Prioridade = prioridade;
        return this;
    }

    public TarefaBuilder ComStatus(Status status)
    {
        Status = status;
        return this;
    }

    public TarefaBuilder ComUsuarioId(Guid id)
    {
        UsuarioId = id;
        return this;
    }

    public Tarefa Build()
    {
        return new Tarefa(Id, Titulo, Descricao, DataCriacao, DataVencimento, Prioridade, Status, UsuarioId);
    }
}
