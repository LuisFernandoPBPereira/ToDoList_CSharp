using ToDoList.Application.DTOs.CategoriaDTOs;
using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Errors.Usuario;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class AtualizarCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;

    public AtualizarCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(Guid usuarioId, AtualizarCategoriaDto categoriaDto)
    {
        var categoriaParaAtualizar = await _repository.BuscarCategoriaPorId(categoriaDto.categoriaId);

        if (categoriaParaAtualizar.UsuarioId != usuarioId) return Result.Failure(UsuarioErrors.UsuarioProibidoDeRealizarAcao);

        var categoria = Categoria.Criar(Guid.Empty, categoriaDto.nome, Guid.Empty);

        if (categoria.IsFailure) return Result.Failure(categoria.Error); 

        await _repository.AtualizarCategoria(categoriaDto.categoriaId, categoria.Value);

        return Result.Success();
    }
}
