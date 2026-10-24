using Microsoft.Extensions.Configuration;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _repo;
    private readonly IConfiguration _config;

    public AuthService(
        IUsuarioRepository repo,
        IConfiguration config)
    {
        _repo = repo;
        _config = config;
    }

    public LoginResponse Login(LoginRequest req)
    {
        // Coloque aqui a lógica de autenticação existente.
        throw new NotImplementedException();
    }
}