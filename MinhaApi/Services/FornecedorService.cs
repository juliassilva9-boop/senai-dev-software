
//API 


using MinhaApi.Models;
using MinhaApi.Services;
using MinhaApi.Repositories;
public class FornecedorService(IFornecedorRepository repo) : IFornecedorService
{
  private readonly IFornecedorRepository _repo = repo;

    public IEnumerable<Fornecedor> GetAll()
      => _repo.GetAll();

  public Fornecedor? GetById(int id)
      => _repo.GetById(id);

 public Fornecedor Create(Fornecedor fornecedor)
{
    if (fornecedor == null)
        throw new ArgumentException("Fornecedor inválido");

    _repo.Add(fornecedor);
    return fornecedor;
}

  public Fornecedor? Update(int id, Fornecedor f)
  {
      if (_repo.GetById(id) == null) return null;
      f.Id = id;
      _repo.Update(fornecedor: f);
      return f;
  }

    public bool Delete(int id) {
        
        var fornecedor = _repo.GetById(id);

        if (fornecedor == null)
            return false;

        _repo.Delete(id);

        return true;
    }

    public bool Delete(string cnpj)
    {
        
        var fornecedor = _repo.GetBycnpj(cnpj);

        if (fornecedor == null)
            return false;

        _repo.Delete(cnpj);

        return true;
    }
    

     public Fornecedor? Update(int Cnpj, Fornecedor f)
  {
      if (_repo.GetBycnpj(Cnpj) == null) return null;
      f.Cnpj = Cnpj;
      _repo.Update(fornecedor: f);
      return f;
  }



    public Fornecedor? GetByNome(string Nome, Fornecedor fornecedor)
    {
    
      if (_repo.GetBynome(Nome) == null) return null;
      fornecedor.Nome = Nome;
      _repo.Update(fornecedor);
      return fornecedor;
  
    }



    public Fornecedor GetByNome(string nome)
    {
        throw new NotImplementedException();
    }

    public Fornecedor GetById(string cnpj)
    {
        throw new NotImplementedException();
    }
}
