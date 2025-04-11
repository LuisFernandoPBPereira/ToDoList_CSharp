namespace ToDoList.Domain.Entities;

public class Categoria
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Guid UsuarioId { get; set; }

    public ICollection<Tarefa> Tarefas { get; set; } = [];
}
