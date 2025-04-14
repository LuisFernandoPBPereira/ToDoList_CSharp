using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infraestructure.Data;
using ToDoList.Infraestructure.Entities;
using ToDoList.Infraestructure.Mappers;

namespace ToDoList.Infraestructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<UsuarioIdentity> _userManager;
    private readonly ToDoListContext _context;

    public UsuarioRepository(UserManager<UsuarioIdentity> userManager, ToDoListContext context, IConfiguration configuration)
    {
        _userManager = userManager;
        _context = context;
        _configuration = configuration;
    }

    public async Task AtualizarUsuario(Guid usuarioId, Usuario usuario)
    {
        var usuarioIdentity = await _userManager.FindByIdAsync(usuarioId.ToString());

        if (usuarioIdentity == null) throw new Exception("Usuário inexistente");

        usuarioIdentity.UserName = usuario.Nome;

        await _userManager.UpdateAsync(usuarioIdentity);
    }

    public async Task<Usuario> BuscarUsuario(Guid usuarioId)
    {
        var usuarioIdentity = await _userManager.FindByIdAsync(usuarioId.ToString());

        if (usuarioIdentity == null) throw new Exception("Usuário inexistente");

        return UsuarioMapper.ToDomain(usuarioIdentity);
    }

    public async Task<IEnumerable<Usuario>> BuscarUsuarios(int pagina, int totalUsuarios)
    {
        var usuariosEntity = await _context.Users.Skip(pagina).Take(totalUsuarios).AsNoTracking().ToListAsync();

        var usuarios = usuariosEntity.Select(x => new Usuario
        {
            Id = x.Id,
            Nome = x.UserName!,
            Email = x.Email!
        }).ToList();

        return usuarios;
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

    public async Task<bool> RedefinirSenha(string email, string senhaNova)
    {
        var usuarioIdentity = await _userManager.FindByEmailAsync(email);

        if (usuarioIdentity is null) return false;

        var hash = _userManager.PasswordHasher.HashPassword(usuarioIdentity, senhaNova);
        usuarioIdentity.PasswordHash = hash;

        var resultUpdatePassword = await _userManager.UpdateAsync(usuarioIdentity);
        
        if (!resultUpdatePassword.Succeeded) return false;
        
        var resultUpdateSecurityStamp = await _userManager.UpdateSecurityStampAsync(usuarioIdentity);

        if (!resultUpdateSecurityStamp.Succeeded) return false;

        return true;
    }

    public async Task RemoverUsuario(Guid usuarioId)
    {
        var usuario = await _context.Users.Where(x => x.Id == usuarioId).FirstOrDefaultAsync();

        if (usuario is null) throw new Exception("Usuário inexistente");
            
        _context.Users.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}
