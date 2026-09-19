
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
 public IEnumerable<Venda> GetAll() {
      var lista = new List<Venda>();
      using var conn = new MySqlConnection(_connectionString);
      conn.Open();

      string sql = @"SELECT venda.id, produto_id, cliente_id, cliente.nome as cliente, 
                        produtos.nome as produto, venda.valor, data_venda
                        FROM venda
                        JOIN cliente ON cliente.id = venda.cliente_id
                        JOIN produtos ON produtos.id = venda.produto_id";
      using var cmd = new MySqlCommand(sql, conn);
      using var reader = cmd.ExecuteReader();

      while (reader.Read()) {
          lista.Add(new Venda {
              Id = reader.GetInt32("id"),
              Cliente_id = reader.GetInt32("cliente_id"),
              Produto_id = reader.GetInt32("produto_id"),
              Valor = reader.GetDecimal("valor"),
              Data_venda = reader.GetDateTime("data_venda")
              
          });
      }
      return lista;
  }

    public Venda? GetById(int id) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();

    string sql = "SELECT id, cliente_id, produto_id, valor, data_venda FROM venda WHERE id = @Id";
    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id", id);

    using var reader = cmd.ExecuteReader();
    if (reader.Read())
    {
        return new Venda
        {
            Id = reader.GetInt32("id"),
            Cliente_id = reader.GetInt32("cliente_id"),
            Produto_id = reader.GetInt32("produto_id"),
            Valor = reader.GetDecimal("valor"),
            Data_venda = reader.GetDateTime("data_venda")
        };
    }

    return null;
}
}