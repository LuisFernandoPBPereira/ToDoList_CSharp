using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Repositories;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> BuscarCategorias(Guid usuarioId, int inicioPaginacao, int totalCategorias);
    Task<IEnumerable<Categoria>> BuscarCategorias(int inicioPaginacao, int totalCategorias);
    Task<Categoria> BuscarCategoriaPorId(Guid categoriaId);
    Task<Categoria> BuscarCategoriaPorId(Guid usuarioId, Guid categoriaId);
    Task CriarCategoria(Categoria categoria);
    Task AtualizarCategoria(Guid categoriaId, Categoria categoria);
    Task RemoverCategoria(Guid categoriaId);
}
