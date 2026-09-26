namespace MinhaApi.Models;


public class Fornecedor
{
  
    public required int Cnpj { get; set; }
    public int Id { get; set; }

    public string Nome { get; set; }
        = string.Empty;

    public string Email { get; set; }
        = string.Empty;

    public bool Ativo { get; set; }
        = true;

    public int Produto_id_Fornecedor {get; set;}

    //public int Cliente_id_Fornecedor {get; set;}
}