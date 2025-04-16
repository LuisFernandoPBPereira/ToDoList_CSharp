using ToDoList.Domain.Enums;

namespace ToDoList.Application.DTOs.TarefaDTOs;

public record AtualizarStatusTarefaDto(Guid tarefaId, Status status);
