using MinhaApi.Models;

namespace MinhaApi.Services;

public interface IFornecedorService
{
    IEnumerable<Fornecedor> GetAll();
    Fornecedor? GetById(int id);
    Fornecedor  Create(Fornecedor fornecedor);
    Fornecedor? Update(int id, Fornecedor fornecedor);
    bool     Delete(int id);
    bool Delete(string cnpj);
    Fornecedor Update(string cnpj, Fornecedor fornecedor);
    Fornecedor GetByNome(string nome);
    Fornecedor GetById(string cnpj);
    //object Create(FornecedoresController fornecedor);
}
