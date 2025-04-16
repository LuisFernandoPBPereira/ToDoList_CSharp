namespace ToDoList;

public static class HttpContextExtension
{
    public static Guid RecuperaIdUsuarioLogado(this HttpContext httpContext)
    {
        httpContext.Items.TryGetValue("UsuarioId", out var usuarioId);
        Guid.TryParse(usuarioId?.ToString(), out Guid usuarioIdFormated);

        return usuarioIdFormated;
    }
}
