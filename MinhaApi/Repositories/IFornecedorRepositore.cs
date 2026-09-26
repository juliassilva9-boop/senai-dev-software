using MinhaApi.Models;

namespace MinhaApi.Repositories;

public interface IFornecedorRepository
{
    IEnumerable<Fornecedor> GetAll();
    Fornecedor? GetById(int id);
    void Add(Fornecedor fornecedor);
    void Update(Fornecedor fornecedor);
    void Delete(int id);
    object GetBycnpj(string cnpj);
    object GetBynome(string nome);
    void Delete(string cnpj);
    object GetBycnpj(int cnpj);
}