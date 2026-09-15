namespace MinhaApi.Models;

public class Venda : NewBaseType
{
    internal int estoque;

    public int Id { get; set; }

    public int Cliente_id { get; set; }
    
    public int Produto_id { get; set; }

    public DateTime Data_venda { get; set; }

    public int Quantidade{ get; set; }
      
    public decimal Valor{ get; set; }
    

    
}