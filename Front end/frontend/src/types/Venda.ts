import type { ReactNode } from "react"

export interface Venda {
  id_Produto: ReactNode
  id_Cliente: ReactNode
  id: number
  cliente_id: number
  produto_id: number
  data_venda: string
  Quantidade: number
  Valor: number
}

export type NovaVenda = Omit<Venda, 'id'>
