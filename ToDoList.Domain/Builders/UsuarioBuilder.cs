using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Builders;

public class UsuarioBuilder
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public UsuarioBuilder ComId(Guid id)
    {
        Id = id;
        return this;
    }

    public UsuarioBuilder ComNome(string nome)
    {
        Nome = nome;
        return this;
    }

    public UsuarioBuilder ComEmail(string email)
    {
        Email = email;
        return this;
    }

    public Usuario Build()
    {
        return new Usuario(Id, Nome, Email);
    }
}
