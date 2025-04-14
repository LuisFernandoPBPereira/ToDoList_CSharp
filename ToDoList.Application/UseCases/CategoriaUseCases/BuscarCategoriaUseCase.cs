using ToDoList.Common;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class BuscarCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;

    public BuscarCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid categoriaId)
    {
        await _repository.BuscarCategoria(categoriaId);

        return Result.Success();
    }
}
