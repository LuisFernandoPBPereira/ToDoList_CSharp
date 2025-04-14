using Microsoft.AspNetCore.Identity;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Application.UseCases.UsuarioUseCases;
using ToDoList.Domain.Repositories;
using ToDoList.Infraestructure.Entities;
using ToDoList.Infraestructure.Repositories;

namespace ToDoList;

public static class DependencyInjection
{
    public static void AddDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoriaRepository, CategoriaRepository>();
        serviceCollection.AddScoped<CriarCategoriaUseCase>();

        serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
        serviceCollection.AddScoped<CadastrarUsuarioUseCase>();

        serviceCollection.AddScoped<ITarefaRepository, TarefaRepository>();
        serviceCollection.AddScoped<CriarTarefaUseCase>();
        serviceCollection.AddScoped<BuscarTarefasUseCase>();
        serviceCollection.AddScoped<AssociarCategoriaEmTarefaUseCase>();
    }
}
