
import { useState } from 'react'
import type { FormEvent } from 'react'
import { vendaService } from '../services/vendaService'

interface Props {
  onVendaCriada: () => void
}

function VendaForm({ onVendaCriada }: Props) {
  const [clienteId, setClienteId] = useState('')
  const [produtoId, setProdutoId] = useState('')
  const [quantidade, setQuantidade] = useState('1')
  const [valor, setValor] = useState('')
  const [dataVenda, setDataVenda] = useState(
    new Date().toISOString().slice(0, 10)
  )
  const [erro, setErro] = useState<string | null>(null)
  const [loading, setLoading] = useState(false)

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    setErro(null)
    setLoading(true)

    try {
      await vendaService.criar({
        cliente_id: Number(clienteId),
        produto_id: Number(produtoId),
        Quantidade: Number(quantidade),
        Valor: Number(valor),
        data_venda: dataVenda,
      })

      setClienteId('')
      setProdutoId('')
      setQuantidade('1')
      setValor('')
      setDataVenda(new Date().toISOString().slice(0, 10))

      onVendaCriada()
    } catch (error) {
      console.error('Erro ao cadastrar venda:', error)
      setErro('Erro ao cadastrar venda. Verifique os dados e tente novamente.')
    } finally {
      setLoading(false)
    }
  }

  return (
    <form onSubmit={handleSubmit} className="form-vendas">
      <h2>Cadastrar Venda</h2>

      {erro && <p role="alert">{erro}</p>}

      <label htmlFor="clienteId">ID do Cliente</label>
      <input
        id="clienteId"
        type="number"
        min="1"
        value={clienteId}
        onChange={(e) => setClienteId(e.target.value)}
        required
      />

      <label htmlFor="produtoId">ID do Produto</label>
      <input
        id="produtoId"
        type="number"
        min="1"
        value={produtoId}
        onChange={(e) => setProdutoId(e.target.value)}
        required
      />

      <label htmlFor="quantidade">Quantidade</label>
      <input
        id="quantidade"
        type="number"
        min="1"
        value={quantidade}
        onChange={(e) => setQuantidade(e.target.value)}
        required
      />

      <label htmlFor="valor">Valor total (R$)</label>
      <input
        id="valor"
        type="number"
        min="0.01"
        step="0.01"
        value={valor}
        onChange={(e) => setValor(e.target.value)}
        required
      />

      <label htmlFor="dataVenda">Data da Venda</label>
      <input
        id="dataVenda"
        type="date"
        value={dataVenda}
        onChange={(e) => setDataVenda(e.target.value)}
        required
      />

      <button type="submit" disabled={loading}>
        {loading ? 'Salvando...' : 'Cadastrar Venda'}
      </button>
    </form>
  )
}

export default VendaForm
