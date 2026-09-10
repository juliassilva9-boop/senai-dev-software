using MinhaApi.Models;

namespace MinhaApi.Repositories;

public interface IVendaRepository
{
    IEnumerable<Venda> GetAll();
    Venda? GetById(int id);
    void Add(Venda venda);
    void Update(Venda Venda);
    void Delete(int id);
}