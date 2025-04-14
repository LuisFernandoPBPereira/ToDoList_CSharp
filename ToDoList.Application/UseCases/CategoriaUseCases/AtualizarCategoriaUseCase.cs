using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class AtualizarCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;

    public AtualizarCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid categoriaId, Categoria categoria)
    {
        await _repository.AtualizarCategoria(categoriaId, categoria);

        return Result.Success();
    }
}
