
import api from './api'
import type { Venda, NovaVenda } from '../types/Venda'

export const vendaService = {
  listar: async (): Promise<Venda[]> => {
    const { data } = await api.get<Venda[]>('/Venda')
    return data
  },

  criar: async (v: NovaVenda): Promise<Venda> => {
    const { data } = await api.post<Venda>('/Venda', v)
    return data
  }
}
