using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Repositories;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> BuscarCategorias(int pagina, int totalCategorias);
    Task<Categoria> BuscarCategoria(Guid categoriaId);
    Task AtualizarCategoria(Guid categoriaId, Categoria categoria);
    Task RemoverCategoria(Guid categoriaId);
}
