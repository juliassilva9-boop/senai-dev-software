
using MinhaApi.Models;
using MinhaApi.Repositories;
using MySqlConnector;


public class VendaRepository : IVendaRepository
{
    private readonly string _connectionString;
    
    public VendaRepository(IConfiguration config) 
      => _connectionString = config.GetConnectionString("DefaultConnection")!;

     

void IVendaRepository.Add(Venda V) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();

    string sql = @"INSERT INTO Venda (Cliente_id, Produto_id, Valor, Data_venda) 
                   VALUES (@Cliente_id, @Produto_id, @Valor, @Data_venda);
                   SELECT LAST_INSERT_ID();";

    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Cliente_id", V.Cliente_id);
    cmd.Parameters.AddWithValue("@Produto_id", V.Produto_id);
    cmd.Parameters.AddWithValue("@Valor", V.Valor);
    cmd.Parameters.AddWithValue("@Data_venda", V.Data_venda);

    // Executa a inserção e recupera o ID gerado pelo MySQL
    var idGerado = cmd.ExecuteScalar();
    V.Id = Convert.ToInt32(idGerado);
}



}