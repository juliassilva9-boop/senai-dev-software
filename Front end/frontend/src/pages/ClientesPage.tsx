
import { useEffect, useState } from 'react'
import type { Cliente } from '../types/Cliente'
import { clienteService } from '../services/clienteService'
import ClienteForm from '../components/ClienteForm'
import ClienteList from '../components/ClienteList'
import Sidebar from '../components/Sidebar'

function ClientesPage() {
  const [clientes, setClientes] = useState<Cliente[]>([])
  const [loading, setLoading] = useState(false)
  const [erro, setErro] = useState<string | null>(null)

  useEffect(() => {
    let ativo = true

    async function carregarClientes() {
      try {
        setLoading(true)
        setErro(null)

        const dados = await clienteService.listar()

        if (ativo) {
          setClientes(dados)
        }
      } catch (error) {
        console.error('Erro ao carregar clientes:', error)

        if (ativo) {
          setErro('Erro ao carregar clientes.')
        }
      } finally {
        if (ativo) {
          setLoading(false)
        }
      }
    }

    carregarClientes()

    return () => {
      ativo = false
    }
  }, [])

  async function atualizarClientes() {
    try {
      setErro(null)
      const dados = await clienteService.listar()
      setClientes(dados)
    } catch (error) {
      console.error('Erro ao atualizar clientes:', error)
      setErro('Erro ao atualizar clientes.')
    }
  }

  return (
    <div className="app-container">
      <Sidebar />

      <main className="main-content">
        <h1>Gestão de Clientes</h1>

        {erro && <p role="alert">{erro}</p>}

        <ClienteForm onClienteCriado={atualizarClientes} />

        <ClienteList
          clientes={clientes}
          loading={loading}
        />
      </main>
    </div>
  )
}

export default ClientesPage
