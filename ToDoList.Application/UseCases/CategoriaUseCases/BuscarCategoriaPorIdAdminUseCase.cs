using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class BuscarCategoriaPorIdAdminUseCase
{
    private readonly ICategoriaRepository _repository;

    public BuscarCategoriaPorIdAdminUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Categoria>> Execute(Guid categoriaId)
    {
        var categoria = await _repository.BuscarCategoriaPorId(categoriaId);

        return Result.Success(categoria);
    }
}
