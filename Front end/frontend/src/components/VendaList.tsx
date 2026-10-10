import type { Venda } from '../types/Venda'

interface Props {
  Venda: Venda[]
  loading: boolean
}

function VendaList({ Venda, loading }: Props) {
  if (loading) return <p>Carregando...</p>
  if (Venda.length === 0)
    return <p>Nenhum Venda cadastrado ainda.</p>

  return (
    <ul>
      {Venda.map(v => (
        <li key={v.id_Venda}>
          <strong>{v.Quantidade}</strong> — {v.id_Cliente}
          {v.id_Venda && <span> (CPF: {v.id_Venda})</span>}
        </li>
      ))}
    </ul>
  )
}
export default VendaList