// Os nomes devem coincidir com o Swagger
export interface Venda {
  id: number
  id_Cliente: number
  id_Venda: number
  Quantidade: number
  quantidade: number
  data_venda: number
  valor: number
 
}
export type NovaVenda = Omit<Venda, 'id' | 'ativo'>