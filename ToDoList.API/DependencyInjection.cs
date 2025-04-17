using ToDoList.Application.Services;
using ToDoList.Application.UseCases.CategoriaUseCases;
using ToDoList.Application.UseCases.TarefaUseCases;
using ToDoList.Application.UseCases.UsuarioUseCases;
using ToDoList.Domain.Repositories;
using ToDoList.Infraestructure.Repositories;
using ToDoList.Infraestructure.Services;

namespace ToDoList;

public static class DependencyInjection
{
    public static void AddDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoriaRepository, CategoriaRepository>();
        serviceCollection.AddScoped<CriarCategoriaUseCase>();
        serviceCollection.AddScoped<AtualizarCategoriaUseCase>();
        serviceCollection.AddScoped<AtualizarCategoriaAdminUseCase>();
        serviceCollection.AddScoped<BuscarCategoriasAdminUseCase>();
        serviceCollection.AddScoped<BuscarCategoriasUseCase>();
        serviceCollection.AddScoped<BuscarCategoriaPorIdAdminUseCase>();
        serviceCollection.AddScoped<BuscarCategoriaPorIdUseCase>();
        serviceCollection.AddScoped<RemoverCategoriaUseCase>();

        serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
        serviceCollection.AddScoped<CadastrarUsuarioUseCase>();
        serviceCollection.AddScoped<AtualizarUsuarioUseCase>();
        serviceCollection.AddScoped<RemoverUsuarioUseCase>();
        serviceCollection.AddScoped<BuscarUsuarioPorIdUseCase>();
        serviceCollection.AddScoped<BuscarUsuariosUseCase>();

        serviceCollection.AddScoped<ITarefaRepository, TarefaRepository>();
        serviceCollection.AddScoped<CriarTarefaUseCase>();
        serviceCollection.AddScoped<BuscarTarefasAdminsUseCase>();
        serviceCollection.AddScoped<BuscarTarefasUseCase>();
        serviceCollection.AddScoped<BuscarTarefaUseCase>();
        serviceCollection.AddScoped<AssociarCategoriaEmTarefaUseCase>();
        serviceCollection.AddScoped<AtualizarTarefaUseCase>();
        serviceCollection.AddScoped<AtualizarStatusUseCase>();
        serviceCollection.AddScoped<RemoverTarefaUseCase>();

        serviceCollection.AddScoped<IEmailService, EmailService>();

        serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}
