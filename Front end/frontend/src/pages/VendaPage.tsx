
import { useEffect, useState } from 'react'
import type { Venda } from '../types/Venda'
import { vendaService } from '../services/vendaService'
import VendaForm from '../components/VendaForm'
import VendaList from '../components/VendaList'

function VendaPage() {
  const [vendas, setVendas] = useState<Venda[]>([])
  const [loading, setLoading] = useState(false)
  const [erro, setErro] = useState('')

  useEffect(() => {
    async function carregarVendas() {
      try {
        setLoading(true)
        setErro('')

        const dados = await vendaService.listar()
        setVendas(dados)
      } catch (error) {
        console.error('Erro ao carregar vendas:', error)
        setErro('Erro ao carregar vendas.')
      } finally {
        setLoading(false)
      }
    }

    carregarVendas()
  }, [])

  return (
    <div>
      <h1>Gestão de Vendas</h1>

      {erro && <p role="alert">{erro}</p>}

      <VendaForm
        onVendaCriada={() => {
          // A lista será atualizada após o cadastro.
          window.location.reload()
        }}
      />

      <VendaList
        Venda={vendas}
        loading={loading}
      />
    </div>
  )
}

export default VendaPage
