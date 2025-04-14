using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Builders;

public class CategoriaBuilder
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Guid UsuarioId { get; set; }

    public CategoriaBuilder ComId(Guid id)
    {
        Id = id;
        return this;
    }

    public CategoriaBuilder ComNome(string nome)
    {
        Nome = nome;
        return this;
    }

    public CategoriaBuilder ComUsuarioId(Guid usuarioId)
    {
        UsuarioId = usuarioId;
        return this;
    }

    public Categoria Build()
    {
        return new Categoria(Id, Nome, UsuarioId);
    }
}
