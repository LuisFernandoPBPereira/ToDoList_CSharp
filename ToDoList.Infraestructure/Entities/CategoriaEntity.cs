using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Infraestructure.Entities;

[Table("Categoria")]
public class CategoriaEntity
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Guid UsuarioId { get; private set; }

    public ICollection<TarefaEntity> Tarefas { get; set; } = [];
}
