namespace MinhaApi.Models;

public class Venda
{

    public int Id { get; set; }

    public int Cliente_id { get; set; }
    
    public int Produto_id { get; set; }

    public DateTime Data_venda { get; set; }

    public int Quantidade{ get; set; }
      
    public decimal Valor{ get; set; }

    public Venda(int cliente_id, int produto_id, DateTime data_venda, int quantidade, decimal valor)
    {
        Id = 0;
        Cliente_id = cliente_id;
        Produto_id = produto_id;
        Data_venda = data_venda;
        Quantidade = quantidade;
        Valor = valor;
    }

}