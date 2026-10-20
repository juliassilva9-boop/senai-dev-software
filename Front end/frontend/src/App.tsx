
import { useEffect, useState } from 'react'
import './App.css'
import type { Produto } from './types/Produto'
import { produtoService } from './services/produtoService'
import ProdutoForm from './components/ProdutoForm'
import ProdutoList from './components/ProdutoList'

function App() {
  const [produtos, setProdutos] = useState<Produto[]>([])
  const [loading, setLoading] = useState(false)
  const [erro, setErro] = useState<string | null>(null)

  const carregarProdutos = async () => {
    try {
      setLoading(true)
      setErro(null)
      const dados = await produtoService.listar()
      setProdutos(dados)
    } catch {
      setErro('Erro ao carregar produtos.')
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    carregarProdutos()
  }, [])

  return (
    <main className="main-content">
      <h1>Gestão de Produtos</h1>

      <ProdutoForm onProdutoCriado={carregarProdutos} />

      <h2>Produtos Cadastrados</h2>

      {erro && <p className="mensagem-erro">{erro}</p>}

      <ProdutoList produtos={produtos} loading={loading} />
    </main>
  )
}

export default App
