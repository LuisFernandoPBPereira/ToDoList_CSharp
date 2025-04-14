namespace ToDoList.Application.Services;

public interface IEmailService
{
    bool Send(string email, string subject, string message);
}
