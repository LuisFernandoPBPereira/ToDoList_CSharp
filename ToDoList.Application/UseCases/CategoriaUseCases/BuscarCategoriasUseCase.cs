using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class BuscarCategoriasUseCase
{
    private readonly ICategoriaRepository _repository;

    public BuscarCategoriasUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<Categoria>>> Execute(int pagina, int totalCategorias)
    {
        var categorias = await _repository.BuscarCategorias(pagina, totalCategorias);

        return Result.Success(categorias);
    }
}
