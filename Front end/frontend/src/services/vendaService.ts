import api from './api'
import type { Venda, NovaVenda } from '../types/Venda'

export const vendaService = {
  listar: async (): Promise<Venda[]> => {
    const { id } = await api.get('/Venda')
    return id
  },
  criar: async (v: NovaVenda): Promise<Venda> => {
    const { data } = await api.post('/Venda', v)
    return data
  }
}