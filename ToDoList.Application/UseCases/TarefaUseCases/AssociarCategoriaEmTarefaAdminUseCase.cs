using ToDoList.Common;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class AssociarCategoriaEmTarefaAdminUseCase
{
    private readonly ITarefaRepository _repository;

    public AssociarCategoriaEmTarefaAdminUseCase(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid categoriaId, Guid tarefaId)
    {
        await _repository.AssociarCategoria(categoriaId, tarefaId);

        return Result.Success();
    }
}
