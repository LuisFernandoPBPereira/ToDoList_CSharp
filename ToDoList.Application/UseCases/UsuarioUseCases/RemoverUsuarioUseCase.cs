using ToDoList.Common;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.UsuarioUseCases;

public class RemoverUsuarioUseCase
{
    private readonly IUsuarioRepository _repository;

    public RemoverUsuarioUseCase(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid usuarioId)
    {
        await _repository.RemoverUsuario(usuarioId);

        return Result.Success();
    }
}
