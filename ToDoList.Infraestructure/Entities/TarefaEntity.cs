using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.Domain.Enums;

namespace ToDoList.Infraestructure.Entities;

[Table("Tarefa")]
public class TarefaEntity
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataVencimento { get; set; }
    public Prioridade Prioridade { get; set; }
    public Status Status { get; set; }
    public Guid UsuarioId { get; set; }

    public ICollection<CategoriaEntity> Categorias { get; set; } = [];
    public UsuarioIdentity Usuario { get; set; } = new UsuarioIdentity();
}
