using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthService : IAuthService
{
    private readonly IUsuarioRepository _repo;
    private readonly IConfiguration _config;

    public AuthService(IUsuarioRepository repo, IConfiguration config)
    {
        _repo = repo;
        _config = config;
    }

    public LoginResponse Login(LoginRequest req)
    {
        // 1. Busca o usuário ativo pelo e-mail
        var usuario = _repo.BuscarPorEmail(req.Email)
            ?? throw new UnauthorizedAccessException("Credenciais inválidas.");

        // 2. Compara a senha digitada com o hash do banco
        bool senhaOk = BCrypt.Net.BCrypt.Verify(req.Senha, usuario.SenhaHash);
        if (!senhaOk)
            throw new UnauthorizedAccessException("Credenciais inválidas.");

        // 3. Gera o token e monta a resposta
        return new LoginResponse
        {
            Token = GerarToken(usuario),
            Nome  = usuario.Nome,
            Email = usuario.Email
        };
        
    }}

    // GerarToken → próximo slide
    
