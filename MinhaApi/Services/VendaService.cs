
//API 


using MinhaApi.Models;
using MinhaApi.Services;
using MinhaApi.Repositories;

public class VendaService : IVendaService
{
 private readonly IVendaRepository _repositoryVenda;
 private readonly IClienteRepository _repositoryCliente;
 private readonly IProdutoRepository _repositoryProduto;

  public VendaService(IVendaRepository repositoryVenda, IClienteRepository repositoryCliente, IProdutoRepository repositoryProduto)
      => (_repositoryVenda, _repositoryCliente, _repositoryProduto) = (repositoryVenda, repositoryCliente, repositoryProduto);



  public Venda Create(Venda venda){
    
    
    var produto = _repositoryProduto.GetById(venda.Produto_id);
    if (produto == null)
      throw new ArgumentException("Produto não encontrado");

   if (venda.Quantidade <= 0)
     throw new ArgumentException("Não existe Estoque disponível");
      
    if(produto.Estoque < venda.Quantidade)  
       throw new ArgumentException("Quantidade inválida");

    if(venda.Cliente_id < venda.Cliente_id)  
       throw new ArgumentException("Cliente Invalido");   

    if(venda.Produto_id < venda.Cliente_id)  
       throw new ArgumentException("Produto Invalido");      

    if(venda.Data_venda< venda.Data_venda)  
       throw new ArgumentException("Data de venda inválida");     


    venda.Valor = produto.Preco * venda.Quantidade;
      


      _repositoryVenda.Add(venda);
      return venda;
  }

public IEnumerable<Venda> GetAll()
      => _repositoryVenda.GetAll();

  public Venda? GetById(int id)
      => _repositoryVenda.GetById(id);

public List<ProdutoDto> ObterTodos()
    {
        var produtos = _repo.ObterTodos();

        // ✨ Para cada produto, calcular o base64 da foto
        foreach (var p in produtos)
            p.FotoBase64 = _fotoService.LerBase64(p.Foto);

        return produtos;
    }

    // No método ObterPorId() existente, ADICIONAR antes do return:
    public ProdutoDto? ObterPorId(int id)
    {
        var produto = _repo.ObterPorId(id);
        if (produto is null) return null;

        // ✨ Enriquecer com base64 antes de retornar
        produto.FotoBase64 = _fotoService.LerBase64(produto.Foto);
        return produto;
    }
}