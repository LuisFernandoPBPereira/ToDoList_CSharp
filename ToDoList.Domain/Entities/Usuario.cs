using System.Text.RegularExpressions;
using ToDoList.Common;
using ToDoList.Domain.Errors.Usuario;

namespace ToDoList.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public ICollection<Tarefa> Tarefas { get; set; } = [];

    public Usuario()
    {
        
    }

    public Usuario(Guid id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public static Result<Usuario> Criar(Guid id, string nome, string email)
    {
        var usuario = new Usuario(id, nome, email);

        var result = Validate(usuario);

        if (result.IsFailure) return Result.Failure<Usuario>(result.Error);

        return Result.Success(usuario);
    }

    private static Result Validate(Usuario usuario)
    {
        if (usuario.Id == Guid.Empty) return Result.Failure(UsuarioErrors.IdUsuarioVazio);

        if (string.IsNullOrEmpty(usuario.Nome)) return Result.Failure(UsuarioErrors.NomeUsuarioVazio);

        if (!Regex.IsMatch(usuario.Email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")) return Result.Failure(UsuarioErrors.EmailUsuarioInvalido);

        return Result.Success();
    }
}
