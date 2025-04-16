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

    public async Task AssociarCategoria(Guid categoriaId, Guid tarefaId)
    {
        var categoria = await _context.Categorias.Where(x => x.Id == categoriaId).FirstOrDefaultAsync();
        var tarefa = await _context.Tarefas.Where(x => x.Id == tarefaId).FirstOrDefaultAsync();
        
        if (tarefa is null || categoria is null)
        {
            throw new Exception("Não foi possível associar uma categoria a uma tarefa");
        }

        tarefa.Categorias.Add(categoria);
        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarStatusTarefa(Guid tarefaId, Status status)
    {
        var tarefa = await _context.Tarefas.Where(x => x.Id == tarefaId).FirstOrDefaultAsync();

        if (tarefa is null) throw new Exception();

        tarefa.Status = status;

        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarTarefa(Guid tarefaId, Tarefa tarefa)
    {
        var tarefaEntity = await _context.Tarefas.Where(x => x.Id == tarefaId).FirstOrDefaultAsync();

        if (tarefaEntity is null) throw new Exception("Tarefa inexistente");

        tarefaEntity.Titulo = tarefa.Titulo;
        tarefaEntity.Descricao = tarefa.Descricao;
        tarefaEntity.DataVencimento = tarefa.DataVencimento;
        tarefaEntity.Prioridade = tarefa.Prioridade;
        tarefaEntity.Status = tarefa.Status;

        _context.Tarefas.Update(tarefaEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<Tarefa> BuscarTarefa(Guid tarefaId)
    {
        var tarefa = await _context.Tarefas.Where(x => x.Id == tarefaId).AsNoTracking().FirstOrDefaultAsync();

        if (tarefa is null) throw new Exception("Tarefa inexistente");

        return TarefaMapper.ToDomain(tarefa);
    }

    public async Task<IEnumerable<Tarefa>> BuscarTarefas(Guid usuarioId, int pagina, int totalTarefas)
    {
        return await _context.Tarefas
            .Skip(pagina)
            .Take(totalTarefas)
            .Where(x => x.UsuarioId == usuarioId)
            .Select(x => new Tarefa
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

    public async Task RemoverTarefa(Guid tarefaId)
    {
        var tarefa = await _context.Tarefas.Where(x => x.Id == tarefaId).AsNoTracking().FirstOrDefaultAsync();

        if (tarefa is null) throw new Exception("Tarefa inexistente");

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
    }
}
