using Microsoft.EntityFrameworkCore;
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

    public async Task AtualizarCategoria(Guid categoriaId, Categoria categoria)
    {
        var categoriaEntity = await _context.Categorias.Where(x => x.Id == categoriaId).AsNoTracking().FirstOrDefaultAsync();

        if (categoriaEntity is null) throw new Exception("Categoria inexistente");

        categoriaEntity.Nome = categoria.Nome;

        _context.Categorias.Update(categoriaEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<Categoria> BuscarCategoria(Guid categoriaId)
    {
        var categoria = await _context.Categorias.Where(x => x.Id == categoriaId).AsNoTracking().FirstOrDefaultAsync();
        
        if (categoria is null) throw new Exception("Categoria inexistente");

        return CategoriaMapper.ToDomain(categoria);
    }

    public async Task<IEnumerable<Categoria>> BuscarCategorias(int pagina, int totalCategorias)
    {
        var categoriasEntity = await _context.Categorias.Skip(pagina).Take(totalCategorias).ToListAsync();

        var categorias = categoriasEntity.Select(x => new Categoria
        {
            Id = x.Id,
            Nome = x.Nome,
            UsuarioId = x.UsuarioId,
        }).ToList();

        return categorias;
    }

    public async Task CriarCategoria(Categoria categoria)
    {
        var categoriaEntity = CategoriaMapper.ToEntity(categoria);

        await _context.Categorias.AddAsync(categoriaEntity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverCategoria(Guid categoriaId)
    {
        var categoria = await _context.Categorias.Where(x => x.Id == categoriaId).AsNoTracking().FirstOrDefaultAsync();

        if (categoria is null) throw new Exception("Categoria inexistente");

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
    }
}
