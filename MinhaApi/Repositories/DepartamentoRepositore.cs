using MinhaApi.Models;
using MinhaApi.Repositories;
using MySqlConnector;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly string _connectionString;
    public DepartamentoRepository(IConfiguration config) 
      => _connectionString = config.GetConnectionString("DefaultConnection")!;
   public static List<Departamento> Db { get => Db; set => Db = value; }

    public IEnumerable<Departamento> GetAll() {
      var lista = new List<Departamento>();
      using var conn = new MySqlConnection(_connectionString);
      conn.Open();

      string sql = "SELECT id_departamento, nome, Descrição, ativo FROM fornecedor";
      using var cmd = new MySqlCommand(sql, conn);
      using var reader = cmd.ExecuteReader();

      while (reader.Read()) {
          lista.Add(new Departamento {
            id_departamento = reader.GetInt32("id_departamento"),
            Nome = reader.GetString("nome"),
            Descricao= reader.GetString("Descricao"),
            Ativo = reader.GetBoolean("ativo")
          
           
         });
      }
        return lista;
    }  


  public Departamento? GetById(int id_departamento)
    {
        using var conn = new MySqlConnection(_connectionString);
            conn.Open();
    
            string sql = "SELECT id_departamento, nome, Descricao, ativo FROM departamento WHERE id_Departamento = @Id_Departamento";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id_departamento);
    
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) {
                return new Departamento {
                    id_departamento = reader.GetInt32("id_departamento"),
                    Nome = reader.GetString("nome"),
                    Descricao = reader.GetString("descricao"),
                    Ativo = reader.GetBoolean("ativo")
                };
            }
            return null;
        
    }
      

public void Add(Departamento d) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();

    string sql = @"INSERT INTO Departamento (id_departamento, nome, Descrição, ativo) 
                   VALUES (@id_departamento@Nome, @Descricao, @Ativo);
                   SELECT LAST_INSERT_ID();";

    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id_Departamento", d.id_departamento);
    cmd.Parameters.AddWithValue("@Nome", d.id_departamento);
    cmd.Parameters.AddWithValue("@descricao", d.Descricao);
    cmd.Parameters.AddWithValue("@Ativo", d.Ativo);

    // Executa a inserção e recupera o ID gerado pelo MySQL
    var idGerado = cmd.ExecuteScalar();
    d.id_departamento = Convert.ToInt32(idGerado);
}
  public void Update(Departamento d) {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();
    string sql = @"UPDATE Departamento
                   SET nome = @Nome, descricao = @descricao, ativo = @Ativo 
                   WHERE id_Departamento = @Id_Departamento";
    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id_Departamento", d.id_departamento);
    cmd.Parameters.AddWithValue("@Nome", d.Nome);
    cmd.Parameters.AddWithValue("@descricao", d.Descricao);
    cmd.Parameters.AddWithValue("@Ativo", d.Ativo);
    cmd.ExecuteNonQuery();
}

public void Delete(int id_departamento)
    {
    using var conn = new MySqlConnection(_connectionString);
    conn.Open();
    string sql = "DELETE FROM Departamento WHERE id_Departamento = @Id_Departamento";
    using var cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Id_departamento", id_departamento);
    cmd.ExecuteNonQuery();
}


}