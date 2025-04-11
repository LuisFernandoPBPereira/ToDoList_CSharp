using Microsoft.AspNetCore.Identity;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infraestructure.Entities;
using ToDoList.Infraestructure.Mappers;

namespace ToDoList.Infraestructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly UserManager<UsuarioIdentity> _userManager;

    public UsuarioRepository(UserManager<UsuarioIdentity> userManager)
    {
        _userManager = userManager;
    }

    public Task AtualizarUsuario(Guid usuarioId, Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> BuscarUsuario(Guid usuarioId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Usuario>> BuscarUsuarios(int pagina, int totalUsuarios)
    {
        throw new NotImplementedException();
    }

    public async Task CadastrarUsuario(Usuario usuario, string senha)
    {
        var usuarioPersistido = await _userManager.FindByEmailAsync(usuario.Email);

        if (usuarioPersistido is not null) throw new Exception();

        var usuarioEntity = UsuarioMapper.ToEntity(usuario);

        var result = await _userManager.CreateAsync(usuarioEntity, senha);

        if (!result.Succeeded) throw new Exception();

        await _userManager.AddToRoleAsync(usuarioEntity, "Comum");
    }

    public Task RemoverUsuario(Guid usuarioId)
    {
        throw new NotImplementedException();
    }
}
