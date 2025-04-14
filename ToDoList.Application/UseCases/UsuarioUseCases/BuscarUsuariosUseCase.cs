using ToDoList.Common;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.UsuarioUseCases;

public class BuscarUsuariosUseCase
{
    private readonly IUsuarioRepository _repository;

    public BuscarUsuariosUseCase(IUsuarioRepository usuarioRepository)
    {
        _repository = usuarioRepository;
    }

    public async Task<Result> Execute(int pagina, int totalUsuarios)
    {
        var usuarios = await _repository.BuscarUsuarios(pagina, totalUsuarios);

        return Result.Success(usuarios);
    }
}
