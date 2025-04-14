using ToDoList.Common;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.UsuarioUseCases;

public class BuscarUsuarioPorIdUseCase
{
    private readonly IUsuarioRepository _repository;

    public BuscarUsuarioPorIdUseCase(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid usuarioId)
    {
        var usuario = await _repository.BuscarUsuario(usuarioId);

        return Result.Success(usuario);
    }
}
