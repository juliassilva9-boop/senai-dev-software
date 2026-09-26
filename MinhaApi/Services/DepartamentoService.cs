
using MinhaApi.Models;
using MinhaApi.Repositories;
namespace MinhaApi.Services;

public class DepartamentoService : IDepartemntoService
{
  private readonly IDepartamentoRepository _repo;

  public DepartamentoService(IDepartamentoRepository repo)
      => _repo = repo;

  public IEnumerable<Departamento> GetAll()
      => _repo.GetAll();

  public Departamento? GetById(int id_departamento)
      => _repo.GetById(id_departamento);

  public Departamento Create(Departamento Departamento)
  {
      if (Departamento == null )
          throw new ArgumentException("Não está Ativo");
      _repo.Add(Departamento);
      return Departamento;
  }

  public Departamento? Update(int id_Departamento, Departamento Departamento)
  {
      if (_repo.GetById(id_Departamento) == null) return null;
      Departamento.id_departamento = id_Departamento;
      _repo.Update(Departamento);
      return Departamento;
  }

    
    public bool Delete(int id_Departamento) {
        
        var Departamento = _repo.GetById(id_Departamento);

        if (Departamento == null)
            return false;

        _repo.Delete(id_Departamento);

        return true;
    }

   
}

public interface IDepartemntoService
{
}