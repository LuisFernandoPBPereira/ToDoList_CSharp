using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Infraestructure.Entities;

[Table("Categoria")]
public class CategoriaEntity
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Guid UsuarioId { get; set; }

    public ICollection<TarefaEntity> Tarefas { get; set; } = [];
}
