using MinhaApi.Models;

namespace MinhaApi.Repositories;

public interface IDepartamentoRepository
{
    IEnumerable<Departamento> GetAll();
    Departamento? GetById(int id_departamento);
    void Add(Departamento Departamento);
    void Update(Departamento Departamento);
    void Delete(int id_Departamento);
}