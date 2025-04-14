using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.UsuarioUseCases;

public class AtualizarUsuarioUseCase
{
    private readonly IUsuarioRepository _repository;
    
    public AtualizarUsuarioUseCase(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid usuarioId, Usuario usuario)
    {
        if (string.IsNullOrEmpty(usuario.Nome)) return Result.Failure(UsuarioErrors.NomeUsuarioVazio);

        await _repository.AtualizarUsuario(usuarioId, usuario);

        return Result.Success();
    }
}
