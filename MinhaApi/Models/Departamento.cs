namespace MinhaApi.Models;

public class Departamento 
{

    public int id_departamento { get; set; }

    public string Nome { get; set; }
        = string.Empty;

    public string Descricao { get; set; }
        = string.Empty;

    public bool Ativo { get; set; }
        = true;

}