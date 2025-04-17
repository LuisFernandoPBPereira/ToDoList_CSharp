using ToDoList.Common;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.TarefaUseCases;

public class AssociarCategoriaEmTarefaUseCase
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public AssociarCategoriaEmTarefaUseCase(ITarefaRepository tarefaRepository, ICategoriaRepository categoriaRepository)
    {
        _tarefaRepository = tarefaRepository;
        _categoriaRepository = categoriaRepository;
    }

    public async Task<Result> Execute(Guid usuarioId, Guid categoriaId, Guid tarefaId)
    {
        var tarefa = await _tarefaRepository.BuscarTarefaPorId(tarefaId);
        var categoria = await _categoriaRepository.BuscarCategoriaPorId(categoriaId);

        if(categoria.UsuarioId != usuarioId || tarefa.UsuarioId != usuarioId)
        {
            return Result.Failure(UsuarioErrors.UsuarioProibidoDeRealizarAcao);
        }

        await _tarefaRepository.AssociarCategoria(categoriaId, tarefaId);

        return Result.Success();
    }
}
