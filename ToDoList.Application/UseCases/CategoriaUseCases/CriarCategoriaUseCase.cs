using ToDoList.Application.DTOs.CategoriaDTOs;
using ToDoList.Common;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCases.CategoriaUseCases;

public class CriarCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;

    public CriarCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Execute(CriarCategoriaDto categoriaDto)
    {
        var categoria = Categoria.Criar(Guid.NewGuid(), categoriaDto.nome, categoriaDto.usuarioId);
        await _repository.CriarCategoria(categoria.Value);

        return Result.Success(categoria);
    }
}
