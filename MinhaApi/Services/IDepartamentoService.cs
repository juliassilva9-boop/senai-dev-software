using MinhaApi.Models;

namespace MinhaApi.Services;

public interface IDepartamentoService
{
    IEnumerable<Departamento> GetAll();
    Departamento? GetById(int id);
    Departamento  Create(Departamento Departamento);
    Departamento? Update(int id_Departamento, Departamento Departamento);
    bool     Delete(int id_Departamento);
    object Update(int id_Departamento);
}
