using ToDoList.Domain.Builders;
using ToDoList.Domain.Entities;
using ToDoList.Infraestructure.Entities;

namespace ToDoList.Infraestructure.Mappers;

public static class UsuarioMapper
{
    public static Usuario ToDomain(UsuarioIdentity usuarioEntity)
    {
        var usuarioBuilder = new UsuarioBuilder();
        return usuarioBuilder.ComId(usuarioEntity.Id)
                             .ComNome(usuarioEntity.UserName)
                             .ComEmail(usuarioEntity.Email)
                             .Build();
    }

    public static UsuarioIdentity ToEntity(Usuario usuario)
    {
        return new UsuarioIdentity
        {
            Id = usuario.Id,
            UserName = usuario.Nome,
            Email = usuario.Email,
        };
    }
}
