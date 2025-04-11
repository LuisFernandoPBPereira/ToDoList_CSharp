using System.Text.RegularExpressions;
using ToDoList.Common;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Errors.Tarefa;
using ToDoList.Domain.Errors.Usuario;

namespace ToDoList.Domain.Entities;

public class Tarefa
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataVencimento { get; set; }
    public Prioridade Prioridade { get; set; }
    public Status Status { get; set; }
    public Guid UsuarioId { get; set; }

    public ICollection<Categoria> Categorias { get; set; } = [];
    public Usuario Usuario { get; set; } = new Usuario();

    public Tarefa()
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

    public static Result<Tarefa> Criar(Guid id, string titulo, string descricao, DateTime dataCriacao, DateTime dataVencimento, Prioridade prioridade, Status status, Guid usuarioId)
    {
        var tarefa = new Tarefa(id, titulo, descricao, dataCriacao, dataVencimento, prioridade, status, usuarioId);

        var result = Validate(tarefa);

        if (result.IsFailure) return Result.Failure<Tarefa>(result.Error);

        return Result.Success(tarefa);
    }

    private static Result Validate(Tarefa tarefa)
    {
        if (tarefa.Id == Guid.Empty) return Result.Failure(TarefaErrors.IdTarefaVazio);

        if (string.IsNullOrEmpty(tarefa.Titulo)) return Result.Failure(TarefaErrors.TituloTarefaVazio);

        if (tarefa.DataVencimento < DateTime.Now) return Result.Failure(TarefaErrors.DataVencimentoNoPassado);

        return Result.Success();
    }
}
