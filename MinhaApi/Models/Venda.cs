namespace MinhaApi.Models;

public class Venda : NewBaseType
{
    public int Id { get; set; }

    public int Cliente_id { get; set; }
    public int Produto_id { get; set; }

    public DateTime Data_venda { get; set; }
      

    public float Valor{ get; set; }
    

    
}