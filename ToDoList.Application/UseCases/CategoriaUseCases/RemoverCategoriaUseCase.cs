using ToDoList.Common;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class RemoverCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;

    public RemoverCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid usuarioId, Guid categoriaId)
    {
        var categoria = await _repository.BuscarCategoriaPorId(categoriaId);

        if (categoria.UsuarioId != usuarioId) return Result.Failure(UsuarioErrors.UsuarioProibidoDeRealizarAcao);

        await _repository.RemoverCategoria(categoriaId);

        return Result.Success();
    }
}
