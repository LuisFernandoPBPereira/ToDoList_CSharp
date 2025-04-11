using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> BuscarUsuarios(int pagina, int totalUsuarios);
    Task<Usuario> BuscarUsuario(Guid usuarioId);
    Task AtualizarUsuario(Guid usuarioId, Usuario usuario);
    Task RemoverUsuario(Guid usuarioId);
    Task CadastrarUsuario(Usuario usuario, string senha);
}
