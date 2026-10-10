
import { useState } from 'react'
import { VendaService } from '../services/vendaService'

interface Props {
  onVendaCriada: () => void
}

function VendaForm({ onVendaCriada }: Props) {
  const [id_Cliente, setid_Cliente] = useState('')
  const [id_Venda, setid_Venda] = useState('')
  const [Quantidade, setQuantidade] = useState('')
  const [erro, setErro] = useState<string | null>(null)
  const [loading, setLoading] = useState(false)

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    setErro(null)

    try {
      setLoading(true)

      await VendaService.criar({
        id_Cliente: Number(id_Cliente),
        id_Venda: Number(id_Venda),
        Quantidade: Number(Quantidade)
      })

      setid_Cliente('')
      setid_Venda('')
      setQuantidade('')

      onVendaCriada()
    } catch {
      setErro('Erro ao cadastrar. Tente novamente.')
    } finally {
      setLoading(false)
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>Cadastrar Venda</h2>

      {erro && <p>{erro}</p>}

      <label htmlFor="id_Cliente">ID do Cliente</label>
      <input
        id="id_Cliente"
        type="number"
        min="1"
        value={id_Cliente}
        onChange={e => setid_Cliente(e.target.value)}
        required
      />

      <label htmlFor="id_Venda">ID da Venda</label>
      <input
        id="id_Venda"
        type="number"
        min="1"
        value={id_Venda}
        onChange={e => setid_Venda(e.target.value)}
        required
      />

      <label htmlFor="Quantidade">Quantidade</label>
      <input
        id="Quantidade"
        type="number"
        min="1"
        value={Quantidade}
        onChange={e => setQuantidade(e.target.value)}
        required
      />

      <button type="submit" disabled={loading}>
        {loading ? 'Salvando...' : 'Cadastrar'}
      </button>
    </form>
  )
}

export default VendaForm
 