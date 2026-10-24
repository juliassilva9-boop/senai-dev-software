
import { useEffect, useState } from 'react'
import type { Produto } from '../types/Produto'
import { produtoService } from '../services/produtoService'
import ProdutoForm from '../components/ProdutoForm'
import ProdutoList from '../components/ProdutoList'
import Sidebar from '../components/Sidebar'

function ProdutosPage() {
  const [produtos, setProdutos] = useState<Produto[]>([])
  const [loading, setLoading] = useState(false)
  const [erro, setErro] = useState<string | null>(null)

  useEffect(() => {
    async function carregarProdutos() {
      try {
        setLoading(true)
        setErro(null)

        const dados = await produtoService.listar()
        setProdutos(dados)
      } catch (error) {
        console.error('Erro ao carregar produtos:', error)
        setErro('Erro ao carregar produtos.')
      } finally {
        setLoading(false)
      }
    }

    carregarProdutos()
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
    <div className="app-container">
      <Sidebar />

      <main className="main-content">
        <h1>Gestão de Produtos</h1>

        <ProdutoForm onProdutoCriado={atualizarProdutos} />

        {erro && <p role="alert">{erro}</p>}

        <ProdutoList
          produtos={produtos}
          loading={loading}
        />
      </main>
    </div>
  )
}

export default ProdutosPage
