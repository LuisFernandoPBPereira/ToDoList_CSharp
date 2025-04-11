using ToDoList.Common.Errors;

namespace ToDoList.Domain.Errors.Tarefa;

public class TarefaErrors
{
    public static readonly Error IdTarefaVazio = Error.Failure(
    "Tarefa.Failure",
    "O ID da Tarefa não pode ser vazio.");
    
    public static readonly Error TituloTarefaVazio = Error.Failure(
    "Tarefa.Failure",
    "O Título da Tarefa não pode ser vazio.");

    public static readonly Error DataVencimentoNoPassado = Error.Failure(
    "Tarefa.Failure",
    "A Data de Vencimento da Tarefa não pode estar no passado.");
}
