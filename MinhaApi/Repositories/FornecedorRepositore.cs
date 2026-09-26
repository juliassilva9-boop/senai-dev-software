using MinhaApi.Models;
using MinhaApi.Repositories;
using MySqlConnector;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly string _connectionString;
    public FornecedorRepository(IConfiguration config) 
      => _connectionString = config.GetConnectionString("DefaultConnection")!;
    
 
    public static List<Fornecedor> Db { get => Db; set => Db = value; }

    public IEnumerable<Fornecedor> GetAll() {
      var lista = new List<Fornecedor>();
      using var conn = new MySqlConnection(_connectionString);
      conn.Open();

      string sql = "SELECT id, nome, email, cnpj, ativo FROM fornecedor";
      using var cmd = new MySqlCommand(sql, conn);
      using var reader = cmd.ExecuteReader();

      while (reader.Read()) {
          lista.Add(new Fornecedor {
              Id = reader.GetInt32("id"),
              Nome = reader.GetString("nome"),
              Email = reader.GetString("email"),
              Cnpj = reader.GetInt32("cnpj"),
              Ativo = reader.GetBoolean("ativo")
          });
      }
      return lista;
  }

  public Fornecedor? GetById(int id)
    {
        using var conn = new MySqlConnection(_connectionString);
            conn.Open();
    
            string sql = "SELECT id, nome, email, cnpj, ativo FROM fornecedor WHERE id = @Id";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
    
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) {
                return new Fornecedor {
                    Id = reader.GetInt32("id"),
                    Nome = reader.GetString("nome"),
                    Email = reader.GetString("email"),
                    Cnpj = reader.GetInt32("cnpj"),
                    Ativo = reader.GetBoolean("ativo")
                };
            }
            return null;
        
    }
      

public void Add(Cliente c) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();

    string sql = @"INSERT INTO cliente (nome, email, cpf, ativo) 
                   VALUES (@Nome, @Email, @Cpf, @Ativo);
                   SELECT LAST_INSERT_ID();";

    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Nome", c.Nome);
    cmd.Parameters.AddWithValue("@Email", c.Email);
    cmd.Parameters.AddWithValue("@Cpf", c.Cpf);
    cmd.Parameters.AddWithValue("@Ativo", c.Ativo);

    // Executa a inserção e recupera o ID gerado pelo MySQL
    var idGerado = cmd.ExecuteScalar();
    c.Id = Convert.ToInt32(idGerado);
}
  public void Update(Cliente c) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();
    string sql = @"UPDATE cliente
                   SET nome = @Nome, Email = @Email, cpf = @Cpf, ativo = @Ativo 
                   WHERE id = @Id";
    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id", c.Id);
    cmd.Parameters.AddWithValue("@Nome", c.Nome);
    cmd.Parameters.AddWithValue("@Email", c.Email);
    cmd.Parameters.AddWithValue("@Cpf", c.Cpf);
    cmd.Parameters.AddWithValue("@Ativo", c.Ativo);
    cmd.ExecuteNonQuery();
}

public void Delete(int id)
    {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();
    string sql = "DELETE FROM cliente WHERE id = @Id";
    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id", id);
    cmd.ExecuteNonQuery();
}

public void Add(Fornecedor p) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();

    string sql = @"INSERT INTO fornecedor (nome, email, cnpj, ativo) 
                   VALUES (@Nome, @Email, @Cnpj, @Ativo);
                   SELECT LAST_INSERT_ID();";

    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Nome", p.Nome);
    cmd.Parameters.AddWithValue("@Email", p.Email);
    cmd.Parameters.AddWithValue("@Cnpj", p.Cnpj);
    cmd.Parameters.AddWithValue("@Ativo", p.Ativo);

    // Executa a inserção e recupera o ID gerado pelo MySQL
    var idGerado = cmd.ExecuteScalar();
    p.Id = Convert.ToInt32(idGerado);
}
 public void Update(Fornecedor p) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();
    string sql = @"UPDATE Fornecedor 
                   SET nome = @Nome, email = @Email, cnpj = @Cnpj, ativo = @Ativo 
                   WHERE id = @Id";
    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id", p.Id);
    cmd.Parameters.AddWithValue("@Nome", p.Nome);
    cmd.Parameters.AddWithValue("@Email", p.Email);
    cmd.Parameters.AddWithValue("@Cnpj", p.Cnpj);
    cmd.Parameters.AddWithValue("@Ativo", p.Ativo);
    cmd.ExecuteNonQuery();
}

    public object GetBycnpj(string cnpj)
    {
        throw new NotImplementedException();
    }

    public object GetBynome(string nome)
    {
        throw new NotImplementedException();
    }

    public void Delete(string cnpj)
    {
        throw new NotImplementedException();
    }

    public object GetBycnpj(int cnpj)
    {
        throw new NotImplementedException();
    }
}