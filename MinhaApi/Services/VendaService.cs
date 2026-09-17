
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


}