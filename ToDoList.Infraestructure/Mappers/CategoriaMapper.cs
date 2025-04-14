using ToDoList.Domain.Builders;
using ToDoList.Domain.Entities;
using ToDoList.Infraestructure.Entities;

namespace ToDoList.Infraestructure.Mappers;

public static class CategoriaMapper
{
    public static Categoria ToDomain(CategoriaEntity categoriaEntity)
    {
        var categoriaBuilder = new CategoriaBuilder();

        return categoriaBuilder.ComId(categoriaEntity.Id)
                               .ComNome(categoriaEntity.Nome)
                               .ComUsuarioId(categoriaEntity.UsuarioId)
                               .Build();
    }

    public static CategoriaEntity ToEntity(Categoria categoria)
    {
        return new CategoriaEntity
        {
            Id = categoria.Id,
            Nome = categoria.Nome,
            UsuarioId = categoria.UsuarioId
        };
    }
}
