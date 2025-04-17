using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class BuscarCategoriasAdminUseCase
{
    private readonly ICategoriaRepository _repository;

    public BuscarCategoriasAdminUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<Categoria>>> Execute(int inicioPaginacao, int totalCategorias)
    {
        var categorias = await _repository.BuscarCategorias(inicioPaginacao, totalCategorias);

        return Result.Success(categorias);
    }
}
