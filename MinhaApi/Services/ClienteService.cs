
using MinhaApi.Models;
using MinhaApi.Repositories;
namespace MinhaApi.Services;

public class ClienteService : IClienteService
{
  private readonly IClienteRepository _repo;

  public ClienteService(IClienteRepository repo)
      => _repo = repo;

  public IEnumerable<Cliente> GetAll()
      => _repo.GetAll();

  public Cliente? GetById(int id)
      => _repo.GetById(id);

  public Cliente Create(Cliente cliente)
  {
      if (cliente.Email == null || cliente.Email.Length == 0)
          throw new ArgumentException("Email inválido");
      _repo.Add(cliente);
      return cliente;
  }

  public Cliente? Update(int id, Cliente cliente)
  {
      if (_repo.GetById(id) == null) return null;
      cliente.Id = id;
      _repo.Update(cliente);
      return cliente;
  }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

   
}