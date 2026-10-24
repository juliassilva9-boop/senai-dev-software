
import { useEffect, useState } from 'react'
import type { Produto } from './types/Produto'
import { produtoService } from './services/produtoService'
import ProdutoForm from './components/ProdutoForm'
import ProdutoList from './components/ProdutoList'

function App() {
  const [produtos, setProdutos] = useState<Produto[]>([])
  const [loading, setLoading] = useState(false)
  const [erro, setErro] = useState<string | null>(null)

  useEffect(() => {
    let ativo = true

    async function carregarProdutos() {
      try {
        setLoading(true)
        setErro(null)

        const dados = await produtoService.listar()

        if (ativo) {
          setProdutos(dados)
        }
      } catch (error) {
        console.error('Erro ao carregar produtos:', error)

        if (ativo) {
          setErro('Erro ao carregar produtos.')
        }
      } finally {
        if (ativo) {
          setLoading(false)
        }
      }
    }

    carregarProdutos()

    return () => {
      ativo = false
    }
  }, [])

  async function atualizarProdutos() {
    try {
      setErro(null)
      const dados = await produtoService.listar()
      setProdutos(dados)
    } catch (error) {
      console.error('Erro ao atualizar produtos:', error)
      setErro('Erro ao atualizar produtos.')
    }
  }

  return (
    <div>
      <h1>Gestão de Produtos</h1>

      <ProdutoForm onProdutoCriado={atualizarProdutos} />

      <h2>Produtos Cadastrados</h2>

      {erro && <p style={{ color: 'red' }}>{erro}</p>}

      <ProdutoList
        produtos={produtos}
        loading={loading}
      />
    </div>
  )
}

export default App
