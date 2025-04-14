using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infraestructure.Data;
using ToDoList.Infraestructure.Mappers;

namespace ToDoList.Infraestructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly ToDoListContext _context;
    public CategoriaRepository(ToDoListContext context)
    {
        _context = context;
    }

    public Task AtualizarCategoria(Guid categoriaId, Categoria categoria)
    {
        throw new NotImplementedException();
    }

    public Task<Categoria> BuscarCategoria(Guid categoriaId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Categoria>> BuscarCategorias(int pagina, int totalCategorias)
    {
        throw new NotImplementedException();
    }

    public async Task CriarCategoria(Categoria categoria)
    {
        var categoriaEntity = CategoriaMapper.ToEntity(categoria);

        await _context.Categorias.AddAsync(categoriaEntity);
        await _context.SaveChangesAsync();
    }

    public Task RemoverCategoria(Guid categoriaId)
    {
        throw new NotImplementedException();
    }
}
