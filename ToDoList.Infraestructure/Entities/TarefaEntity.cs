using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.Domain.Enums;

namespace ToDoList.Infraestructure.Entities;

[Table("Tarefa")]
public class TarefaEntity
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public string? Descricao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime DataVencimento { get; private set; }
    public Prioridade Prioridade { get; private set; }
    public Status Status { get; private set; }
    public Guid UsuarioId { get; private set; }

    public ICollection<CategoriaEntity> Categorias { get; private set; } = [];
    public UsuarioIdentity Usuario { get; private set; } = new UsuarioIdentity();
}
