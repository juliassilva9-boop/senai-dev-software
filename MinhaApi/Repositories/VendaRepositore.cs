
using System.Diagnostics;
using MinhaApi.Models;
using MinhaApi.Repositories;
using MySqlConnector;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class VendaRepository : IVendaRepository
{
    private readonly string _connectionString;
    public VendaRepository(IConfiguration config) 
      => _connectionString = config.GetConnectionString("DefaultConnection")!;
    
    
  public Venda? GetById(int id) {
    using var conn = new MySqlConnection (_connectionString) 
    conn.Open();
     }
     

public void Add(Venda V) {
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
  public void Update(Venda v) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();
    string sql = @"UPDATE Venda
                   SET Cliente_id = @Cliente_id, Produto_id = @Produto_id, Valor = @Valor, Data_venda = @Data_venda 
                   WHERE id = @Id";
    using var cmd = new MySqlCommand(sql, conn);
       
    cmd.Parameters.AddWithValue("@Cliente_id", v.Cliente_id);
    cmd.Parameters.AddWithValue("@Produto_id", v.Produto_id);
    cmd.Parameters.AddWithValue("@Valor", v.Valor);
    cmd.Parameters.AddWithValue("@Data_venda", v.Data_venda);
    cmd.ExecuteNonQuery();
}

public void Delete(int id) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();
    string sql = "DELETE FROM produtos WHERE id = @Id";
    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id", id);
    cmd.ExecuteNonQuery();
}

    private static object GetDebuggerDisplay()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Venda> GetAll()
    {
        throw new NotImplementedException();
    }
}