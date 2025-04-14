namespace ToDoList.Application.Services;

public interface IAuthenticationService
{
    Task<string> Login(string email, string senha);
}
