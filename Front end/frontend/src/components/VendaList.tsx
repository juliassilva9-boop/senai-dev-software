
import type { Venda } from '../types/Venda'

interface Props {
  Venda: Venda[]
  loading: boolean
}

function VendaList({ Venda, loading }: Props) {
  if (loading) return <p>Carregando vendas...</p>

  if (Venda.length === 0) {
    return <p>Nenhuma venda cadastrada ainda.</p>
  }

  return (
    <div className="tabela-container">
      <h2>Lista de Vendas</h2>

      <table className="tabela-vendas">
      <thead>
      <tr>
            <th>ID</th>
            <th>Cliente</th>
            <th>Produto</th>
            <th>Quantidade</th>
            <th>Valor</th>
            <th>Data da venda</th>
          </tr>
        </thead>

        <tbody>
          {Venda.map((v) => (
            <tr key={v.id}>
              <td>{v.id}</td>
              <td>{v.id_Cliente}</td>
              <td>{v.id_Produto}</td>
              <td>{v.Quantidade}</td>
              <td>
                {Number(v.valor).toLocaleString('pt-BR', {
                  style: 'currency',
                  currency: 'BRL',
                })}
              </td>
              <td>
                {v.data_venda
                  ? new Date(v.data_venda).toLocaleDateString('pt-BR')
                  : '-'}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default VendaList
