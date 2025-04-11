using System.Text.RegularExpressions;
using ToDoList.Application.DTOs.UsuarioDTOs;
using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.UsuarioUseCases;

public class CadastrarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public CadastrarUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Result> Execute(CriarUsuarioDto usuarioDto)
    {
        var usuario = Usuario.Criar(Guid.NewGuid(), usuarioDto.nome, usuarioDto.email);

        if (usuario.IsFailure) return Result.Failure(usuario.Error);

        if (usuarioDto.senha != usuarioDto.confirmacaoSenha) return Result.Failure(UsuarioErrors.SenhasDiferentes);

        if (!Regex.IsMatch(usuarioDto.senha, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z0-9]).{8,}$"))
            return Result.Failure(UsuarioErrors.SenhaInvalida);

        if (usuario.IsFailure) return Result.Failure(usuario.Error);

        await _usuarioRepository.CadastrarUsuario(usuario.Value, usuarioDto.senha);

        return Result.Success();
    }
}
