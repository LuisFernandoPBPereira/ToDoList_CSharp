using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.UsuarioUseCases;

public class BuscarUsuariosUseCase
{
    private readonly IUsuarioRepository _repository;

    public BuscarUsuariosUseCase(IUsuarioRepository usuarioRepository)
    {
        _repository = usuarioRepository;
    }

    public async Task<Result<IEnumerable<Usuario>>> Execute(int inicioPaginacao, int totalUsuarios)
    {
        var usuarios = await _repository.BuscarUsuarios(inicioPaginacao, totalUsuarios);

        return Result.Success(usuarios);
    }
}
