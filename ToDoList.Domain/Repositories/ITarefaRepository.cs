using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Repositories;

public interface ITarefaRepository
{
    /// <summary>
    /// Este método busca todas as tarefas do usuário logado na aplicação, pode ser executado apenas pela Role: <see cref="Roles.Comum"/>
    /// </summary>
    /// <param name="inicioPaginacao"></param>
    /// <param name="totalTarefas"></param>
    /// <returns>Lista de Tarefas</returns>
    Task<IEnumerable<Tarefa>> BuscarTarefas(Guid usuarioId, int inicioPaginacao, int totalTarefas);

    /// <summary>
    /// Este método busca todas as tarefas de todos os usuários da aplicação, pode ser executado apenas pela Role: <see cref="Roles.Admin"/>
    /// </summary>
    /// <param name="inicioPaginacao"></param>
    /// <param name="totalTarefas"></param>
    /// <returns>Lista de Tarefas</returns>
    Task<IEnumerable<Tarefa>> BuscarTarefas(int inicioPaginacao, int totalTarefas);
    Task<Tarefa> BuscarTarefaPorId(Guid tarefaId);
    Task CriarTarefa(Tarefa tarefa);
    Task AtualizarStatusTarefa(Guid tarefaId, Status status);
    Task AtualizarTarefa(Guid tarefaId, Tarefa tarefa);
    Task RemoverTarefa(Guid tarefaId);
    Task AssociarCategoria(Guid categoriaId, Guid tarefaId);
}
