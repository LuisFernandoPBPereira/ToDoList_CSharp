using ToDoList.Common;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class RemoverCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;

    public RemoverCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid categoriaId)
    {
        await _repository.RemoverCategoria(categoriaId);

        return Result.Success();
    }
}
