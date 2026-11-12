import { useState } from 'react'
import { produtoService } from '../services/produtoService'
import FotoUpload from '../components/produtos/FotoUpload'
import { useParams } from 'react-router-dom'

interface Props {
  onProdutoCriado: () => void
  
}

function ProdutoForm({ onProdutoCriado }: Props) {
  const [nome,    setNome]    = useState('')
  const [preco,   setPreco]   = useState('')
  const [loading, setLoading] = useState(false)
  const [erro,    setErro]    = useState<string | null>(null)
  const [fotoBase64Atual, setFotoBase64Atual] = useState<string | null>(null) 
  const { id } = useParams()
  const modoEdicao = !!id


  async function carregarProduto() {
  if (!id) return
  const produto = await produtoService.buscarPorId(Number(id))
  setNome(produto.nome)
  setPreco({ value: produto.preco })
  //setEstoque(produto.estoque)
  // ✨ Guardar a data URL que veio da API:
  setFotoBase64Atual(produto.fotoBase64 ?? null)
}

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setErro(null)
    try {
      setLoading(true)
      await produtoService.criar({
        nome,
        preco: Number(preco),
        estoque: 0, 
        ativo: true// estoque inicial
      })
      setNome('')
      setPreco({ value: '' })
      setEstoque('')
      setAtivo('')
      onProdutoCriado()
    } catch {
      setErro('Erro ao cadastrar. Tente novamente.')
    } finally {
      setLoading(false)
    }
  }
  function setEstoque(value: string): void {
    throw new Error('Function not implemented.')
  }

  function setAtivo(value: string): void {
    throw new Error('Function not implemented.')
  }
    function setPreco({ value }: { value: string }): void {
    throw new Error('Function not implemented.')
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>Cadastrar Produto</h2>

      {erro && (
        <p style={{ color: 'red' }}>{erro}</p>
      )}

      <div>
        <label htmlFor="nome">Nome</label>
        <input
          id="nome"
          type="text"
          value={nome}
          onChange={e => setNome(e.target.value)}
          required
        />
      </div>

      <div>
        <label htmlFor="preco">Preço</label>
        <input
          id="preco"
          type="number"
          step="0.01"
          value={preco}
          onChange={e => setPreco({ value: e.target.value })}
          required
        />
      </div>

          <div>
        <label htmlFor="Estoque">Estoque</label>
        <input
          id="estoque"
          type="number"
          step="0.01"
          value={estoque}
          onChange={e => setEstoque(e.target.value)}
          required
        />
      </div>

          <div>
        <label htmlFor="ativo">Ativo</label>
        <input
          id="ativo"
          type="number"
          step="0.01"
          value={ativo}
          onChange={e => setAtivo(e.target.value)}
          required
        />
      </div>



      <button type="submit" disabled={loading}>
        {loading ? 'Salvando...' : 'Cadastrar'}
      </button>
      {modoEdicao && (
        <FotoUpload
          produtoId={Number(id)}
          fotoBase64Atual={fotoBase64Atual}
          onAtualizar={carregarProduto}
        />
      )}

    </form>
  )
}
export default ProdutoForm