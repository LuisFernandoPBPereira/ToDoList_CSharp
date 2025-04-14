using ToDoList.Common.Errors;

namespace ToDoList.Domain.Errors.Categoria;

public class CategoriaErrors
{
    public static readonly Error NomeCategoriaInvalido = Error.Failure(
    "Categoria.Failure",
    "O nome da Categoria não pode ser vazio.");
}
