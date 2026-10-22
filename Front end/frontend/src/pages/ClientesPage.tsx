import { useEffect, useState } from 'react'
import type { Cliente } from '../types/Cliente'
import { clienteService } from '../services/clienteService'
import ClienteForm from '../components/ClienteForm'
import ClienteList from '../components/ClienteList'
import Sidebar from '../components/Sidebar'

function ClientesPage() {
  const [clientes, setClientes] = useState<Cliente[]>([])
  const [loading, setLoading] = useState(false)

  const carregarClientes = async () => {
    setLoading(true)
    try { setClientes(await clienteService.listar()) }
    finally { setLoading(false) }
  }

  useEffect(() => { carregarClientes() }, [])

  return (
    <div className="app-container">
  <Sidebar />
  <main className="main-content">
    <h1>Gestão de Clientes</h1>
    <ClienteForm onClienteCriado={carregarClientes} />
    <ClienteList clientes={clientes} loading={loading} />
  </main>
</div>

}')
