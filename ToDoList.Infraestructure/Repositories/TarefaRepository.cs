using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Repositories;
using ToDoList.Infraestructure.Data;
using ToDoList.Infraestructure.Mappers;

namespace ToDoList.Infraestructure.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly ToDoListContext _context;

    public TarefaRepository(ToDoListContext context)
    {
        _context = context;
    }

    public Task AtualizarStatusTarefa(Guid tarefaId, Status status, Tarefa tarefa)
    {
        throw new NotImplementedException();
    }

    public Task AtualizarTarefa(Guid tarefaId, Tarefa tarefa)
    {
        throw new NotImplementedException();
    }

    public Task<Tarefa> BuscarTarefa(Guid tarefaId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Tarefa>> BuscarTarefas(int pagina, int totalTarefas)
    {
        return await _context.Tarefas.Skip(pagina).Take(totalTarefas).Select(x => new Tarefa
        {
            Id = x.Id,
            Titulo = x.Titulo,
            Descricao = x.Descricao,
            DataCriacao = x.DataCriacao,
            DataVencimento = x.DataVencimento,
            Prioridade = x.Prioridade,
            Status = x.Status,
            UsuarioId = x.UsuarioId
        }).ToListAsync();
    }

    public async Task CriarTarefa(Tarefa tarefa)
    {
        var tarefaEntity = TarefaMapper.ToEntity(tarefa);
        await _context.Tarefas.AddAsync(tarefaEntity);
        await _context.SaveChangesAsync();
    }

    public Task RemoverTarefa(Guid tarefaId)
    {
        throw new NotImplementedException();
    }
}
