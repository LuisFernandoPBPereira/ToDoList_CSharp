using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class BuscarCategoriaPorIdUseCase
{
    private readonly ICategoriaRepository _repository;

    public BuscarCategoriaPorIdUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Categoria>> Execute(Guid usuarioId, Guid categoriaId)
    {
        var categoria = await _repository.BuscarCategoriaPorId(usuarioId, categoriaId);

        return Result.Success(categoria);
    }
}
