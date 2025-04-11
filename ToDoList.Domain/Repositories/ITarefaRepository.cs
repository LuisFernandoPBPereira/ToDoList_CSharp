using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Repositories;

public interface ITarefaRepository
{
    Task<IEnumerable<Tarefa>> BuscarTarefas(int pagina, int totalTarefas);
    Task<Tarefa> BuscarTarefa(Guid tarefaId);
    Task CriarTarefa(Tarefa tarefa);
    Task AtualizarStatusTarefa(Guid tarefaId, Status status, Tarefa tarefa);
    Task AtualizarTarefa(Guid tarefaId, Tarefa tarefa);
    Task RemoverTarefa(Guid tarefaId);
}
