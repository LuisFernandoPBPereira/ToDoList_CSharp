using ToDoList.Application.UseCases.TarefaUseCases;

namespace ToDoList;

public static class DependencyInjection
{
    public static void AddDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<CriarTarefaUseCase>();
    }
}
