using ToDoList.Domain.Enums;

namespace ToDoList.Application.DTOs.TarefaDTOs;

public record AtualizarTarefaDto(Guid tarefaId, string titulo, string descricao, DateTime dataVencimento, Prioridade prioridade);
