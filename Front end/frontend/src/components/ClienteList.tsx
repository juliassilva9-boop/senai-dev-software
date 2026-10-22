import type { Cliente } from '../types/Cliente'

interface Props {
  clientes: Cliente[]
  loading: boolean
}

function ClienteList({ clientes, loading }: Props) {
  if (loading) return <p>Carregando...</p>
  
  // 1. Defesa: Garante que "clientes" existe e é de fato um Array antes de verificar o tamanho
  if (!clientes || !Array.isArray(clientes) || clientes.length === 0) {
    return <p>Nenhum cliente cadastrado ainda.</p>
  }

  <div className="list-container">
  <table className="data-table">
    <thead>
      <tr>
        <th>Nome</th>
        <th>Email</th>
      </tr>
    </thead>
    <tbody>
      {clientes.map(c => (
        <tr key={c.id}>
          <td><strong>{c.nome}</strong></td>
          <td>{c.email}</td>
        </tr>
      ))}
    </tbody>
  </table>
</div>

}

export default ClienteList
