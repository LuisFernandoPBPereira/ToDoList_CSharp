namespace ToDoList.Application.DTOs.UsuarioDTOs;

public record CriarUsuarioDto(string nome, string email, string senha, string confirmacaoSenha);
