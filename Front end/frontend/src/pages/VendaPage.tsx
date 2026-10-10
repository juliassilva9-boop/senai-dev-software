import { useEffect, useState } from 'react'
import type { Venda } from '../types/Venda'
import { vendaService } from '../services/vendaService'
import VendaForm from '../components/VendaForm'
import VendaList from '../components/VendaList'

function VendaPage() {
  const [Venda, setVenda] = useState<Venda[]>([])
  const [loading, setLoading] = useState(false)

  const carregarVendas = async () => {
    setLoading(true)
    try { setVenda(await vendaService.listar()) }
    finally { setLoading(false) }
  }

  useEffect(() => { carregarVendas() }, [])
  return (<div>
    <h1>Gestão de Vendas</h1>
    <VendaForm onVendaCriada={carregarVendas} />
    <VendaList Venda={Venda} loading={loading} />
  </div>)
}
export default VendaPage
