using ToDoList.Common;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class RemoverCategoriaAdminUseCase
{
    private readonly ICategoriaRepository _repository;

    public RemoverCategoriaAdminUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid categoriaId)
    {
        await _repository.RemoverCategoria(categoriaId);

        return Result.Success();
    }
}
