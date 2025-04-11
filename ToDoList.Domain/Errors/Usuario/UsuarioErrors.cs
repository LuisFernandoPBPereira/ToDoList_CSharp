using ToDoList.Common.Errors;

namespace ToDoList.Domain.Errors.Usuario;

public class UsuarioErrors
{
    public static readonly Error IdUsuarioVazio = Error.Failure(
    "Usuario.Failure",
    "O ID do Usuário não pode ser vazio.");
    
    public static readonly Error NomeUsuarioVazio = Error.Failure(
    "Usuario.Failure",
    "O nome do Usuário não pode ser vazio.");

    public static readonly Error EmailUsuarioInvalido = Error.Failure(
    "Usuario.Failure",
    "O Email do Usuário é inválido.");
    
    public static readonly Error SenhasDiferentes = Error.Failure(
    "Usuario.Failure",
    "Não foi possível confirmar a senha do usuário");

    public static readonly Error SenhaInvalida = Error.Failure(
    "Usuario.Failure",
    "A senha deve ter no mínimo 8 caracteres, pelo menos 1 caracter maiúsculo, 1 caracter minúsuclo, 1 número e 1 caracter especial.");
}
