using ToDoList.Domain.Enums;

namespace ToDoList.Application.DTOs.TarefaDTOs;

public record CriarTarefaDto(string titulo,
                        string descricao,
                        DateTime dataCriacao,
                        DateTime dataVencimento,
                        Prioridade prioridade,
                        Status status,
                        Guid usuarioId);