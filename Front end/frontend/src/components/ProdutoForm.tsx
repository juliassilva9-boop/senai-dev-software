
import { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import { produtoService } from '../services/produtoService'
import FotoUpload from '../components/produtos/FotoUpload'

interface Props {
  onProdutoCriado: () => void
}

function ProdutoForm({ onProdutoCriado }: Props) {
  const [nome, setNome] = useState('')
  const [preco, setPreco] = useState('')
  const [estoque, setEstoque] = useState('')
  const [ativo, setAtivo] = useState(true)
  const [loading, setLoading] = useState(false)
  const [erro, setErro] = useState<string | null>(null)
  const [fotoBase64Atual, setFotoBase64Atual] = useState<string | null>(null)

  const { id } = useParams()
  const modoEdicao = !!id

  async function carregarProduto() {
    if (!id) return

    try {
      const produto = await produtoService.buscarPorId(Number(id))

      setNome(produto.nome)
      setPreco(String(produto.preco))
      setEstoque(String(produto.estoque))
      setAtivo(produto.ativo)
      setFotoBase64Atual(produto.fotoBase64 ?? null)
    } catch {
      setErro('Erro ao carregar produto.')
    }
  }

  useEffect(() => {
    if (modoEdicao) {
      carregarProduto()
    }
  }, [id])

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setErro(null)

    try {
      setLoading(true)

      const dados = {
        id: modoEdicao ? Number(id) : undefined,
        nome,
        preco: Number(preco),
        estoque: Number(estoque),
        ativo
      }

      if (modoEdicao) {
        await produtoService.atualizar(Number(id), dados)
      } else {
        await produtoService.criar(dados)
      }

      setNome('')
      setPreco('')
      setEstoque('')
      setAtivo(true)

      onProdutoCriado()

    } catch {
      setErro('Erro ao salvar produto. Tente novamente.')
    } finally {
      setLoading(false)
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>{modoEdicao ? 'Editar Produto' : 'Cadastrar Produto'}</h2>

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
          onChange={e => setPreco(e.target.value)}
          required
        />
      </div>

      <div>
        <label htmlFor="estoque">Estoque</label>
        <input
          id="estoque"
          type="number"
          value={estoque}
          onChange={e => setEstoque(e.target.value)}
          required
        />
      </div>

      <div>
        <label htmlFor="ativo">Ativo</label>
        <input
          id="ativo"
          type="checkbox"
          checked={ativo}
          onChange={e => setAtivo(e.target.checked)}
        />
      </div>

      <button type="submit" disabled={loading}>
        {loading
          ? 'Salvando...'
          : modoEdicao
            ? 'Atualizar'
            : 'Cadastrar'}
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
