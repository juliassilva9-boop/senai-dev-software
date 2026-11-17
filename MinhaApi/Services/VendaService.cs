using MinhaApi.Models;
using MinhaApi.Repositories;

namespace MinhaApi.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repositoryVenda;
        private readonly IClienteRepository _repositoryCliente;
        private readonly IProdutoRepository _repositoryProduto;

        public VendaService(
            IVendaRepository repositoryVenda,
            IClienteRepository repositoryCliente,
            IProdutoRepository repositoryProduto)
        {
            _repositoryVenda = repositoryVenda;
            _repositoryCliente = repositoryCliente;
            _repositoryProduto = repositoryProduto;
        }

        // CRIAR VENDA
        public Venda Create(Venda venda)
        {
            // Verificar se o produto existe
            var produto = _repositoryProduto.GetById(venda.Produto_id);

            if (produto == null)
                throw new ArgumentException("Produto não encontrado.");

            // Verificar se o cliente existe
            var cliente = _repositoryCliente.GetById(venda.Cliente_id);

            if (cliente == null)
                throw new ArgumentException("Cliente não encontrado.");

            // Verificar quantidade
            if (venda.Quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            // Verificar estoque
            if (produto.Estoque < venda.Quantidade)
                throw new ArgumentException("Quantidade indisponível em estoque.");

            // Calcular valor
            venda.Valor = produto.Preco * venda.Quantidade;

            // Salvar venda
            _repositoryVenda.Add(venda);

            return venda;
        }

        // LISTAR VENDAS
        public IEnumerable<Venda> GetAll()
        {
            return _repositoryVenda.GetAll();
        }

        // BUSCAR VENDA POR ID
        public Venda? GetById(int id)
        {
            return _repositoryVenda.GetById(id);
        }
    }
}