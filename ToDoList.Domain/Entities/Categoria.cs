namespace ToDoList.Domain.Entities;

public class Categoria
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Guid UsuarioId { get; private set; }
}
