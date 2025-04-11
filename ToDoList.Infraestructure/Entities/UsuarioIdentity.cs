using Microsoft.AspNetCore.Identity;
using ToDoList.Domain.Entities;

namespace ToDoList.Infraestructure.Entities;

public class UsuarioIdentity : IdentityUser<Guid>
{
    public ICollection<TarefaEntity> Tarefas { get; set; } = [];
}
