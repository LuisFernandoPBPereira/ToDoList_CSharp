using ToDoList.Common;
using ToDoList.Domain.Errors.Categoria;

namespace ToDoList.Domain.Entities;

public class Categoria
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Guid UsuarioId { get; set; }

    public ICollection<Tarefa> Tarefas { get; set; } = [];

    public Categoria()
    {
        
    }

    public Categoria(Guid id, string nome, Guid usuarioId)
    {
        Id = id;
        Nome = nome;
        UsuarioId = usuarioId;
    }

    public static Result<Categoria> Criar(Guid id, string nome, Guid usuarioId)
    {
        var categoria = new Categoria(id, nome, usuarioId);
        var result = Validate(categoria);
        if(result.IsFailure) return Result.Failure<Categoria>(result.Error);

        return Result.Success(categoria);
    }

    private static Result Validate(Categoria categoria)
    {
        if (string.IsNullOrEmpty(categoria.Nome)) return Result.Failure(CategoriaErrors.NomeCategoriaInvalido);

        return Result.Success();
    }
}
