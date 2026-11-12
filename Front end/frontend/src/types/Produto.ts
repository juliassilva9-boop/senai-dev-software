// src/types/Produto.ts
// ⚠️ Os nomes devem ser IDÊNTICOS ao que o Swagger retorna!
// Verifique: "nome" ou "Nome"? "preco" ou "Preco"?
// Encontre a interface Produto e adicione:
export interface Produto {
  id:          number
  nome:        string
  preco:       number
  estoque:     number
  ativo:       boolean
  fotoBase64?: string  // ✨ "data:image/jpeg;base64,..."
                       // undefined = produto sem foto
}
// Obs: não há mais getFotoUrl — a URL já vem pronta da API!
// Tipo para criação — sem o id (gerado pela MinhaAPI)
export type NovoProduto = Omit<Produto, 'id'>