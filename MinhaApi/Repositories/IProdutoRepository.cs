
using MinhaApi.Models;

namespace MinhaApi.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();

        Produto? GetById(int id);

        void Add(Produto p);

        void Update(Produto p);

        void Delete(int id);

        void AtualizarFoto(int id, string? nomeArquivo);
    }
}
