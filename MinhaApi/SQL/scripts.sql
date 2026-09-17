-- 1. Criação do Banco de Dados
CREATE DATABASE IF NOT EXISTS minha_api_db;
USE minha_api_db;

-- 2. Criação da Tabela de Produtos
CREATE TABLE IF NOT EXISTS produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    estoque INT NOT NULL DEFAULT 0,
    ativo TINYINT(1) NOT NULL DEFAULT 1
);


-- 3. Criação da Tabela clientes
CREATE TABLE IF NOT EXISTS clientes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    cpf VARCHAR(11)NOT NULL,
    ativo TINYINT (1) NOT NULL DEFAULT 1
);

-- 4. Criação da Tabela de Vendas
CREATE TABLE IF NOT EXISTS vendas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,
    produto_id INT NOT NULL,
    valor DECIMAL(10,2) NOT NULL,
    data_venda DATETIME NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES clientes(id),
    FOREIGN KEY (produto_id) REFERENCES produtos(id)
);
);

-- 5. Inserção de Dados Iniciais (Carga)
INSERT INTO clientes (nome, email, telefone) 
VALUES 
('João Silva', 'joao.silva@email.com', '11999999999');

INSERT INTO produtos (nome, preco, estoque, ativo) 
VALUES 
('cabo C', 500.60, 45, 1);