# Instruções para Rodar um Projeto .NET 6 API

### Pré-requisitos:
.NET 6 SDK: Certifique-se de que o .NET 6 SDK esteja instalado em sua máquina. 
Editor de código: Escolha um editor de código como Visual Studio, Visual Studio Code ou outro de sua preferência.

## Passos:

### Obter o código:

Clone o repositório: Use o comando git clone para obter uma cópia local do código.

### Abrir o projeto:

Visual Studio: Abra o arquivo de solução (.sln) do projeto no Visual Studio.
Visual Studio Code: Abra a pasta do projeto no Visual Studio Code.

### Restaurar os pacotes:

Terminal integrado: Abra um terminal integrado no seu editor de código (geralmente Ctrl+`) e navegue até a pasta raiz do projeto.
Executar o comando: Execute o comando dotnet restore para restaurar os pacotes NuGet necessários para o projeto.

### Definir o projeto de inicialização:

Visual Studio: No menu "Solution Explorer", clique com o botão direito no projeto principal e selecione "Set as Startup Project".
Visual Studio Code: Certifique-se de que o projeto correto esteja selecionado como projeto de inicialização nas configurações do seu editor de código.

### Executar o projeto:

Visual Studio: Pressione F5 ou clique no botão "Start" na barra de ferramentas.
Visual Studio Code: Use a combinação de teclas Ctrl+F5 ou procure por um comando similar para iniciar o projeto em modo de depuração.



# Documentação do Projeto "UBC Gerenciador de Alunos API"

## 1. Introdução
O objetivo deste projeto é desenvolver uma aplicação web para gerenciar informações de estudantes, incluindo listagem, adição, atualização e exclusão de registros. A aplicação é composta por uma WebAPI desenvolvida com .NET 6 e um front-end desenvolvido em React, incluindo uma tela de login.

Requisitos
Back-end (WebAPI)

Framework: .NET 6

Entity Framework: Usar o EF Core com um banco de dados em memória

Autenticação: Implementar autenticação básica (JWT)

## Endpoints:

GET /api/students: Retorna todos os estudantes (autenticado)

GET /api/students/{id}: Retorna um estudante específico (autenticado)

POST /api/students: Cria um novo estudante (autenticado)

PUT /api/students/{id}: Atualiza um estudante existente (autenticado)

DELETE /api/students/{id}: Deleta um estudante (autenticado)

POST /api/auth/login: Autentica um usuário e retorna um token JWT

## Modelo de Dados:

csharp

Copiar
public class Student
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public int Serie { get; set; }
    public double NotaMedia { get; set; }
    public string Endereco { get; set; }
    public string NomePai { get; set; }
    public string NomeMae { get; set; }
    public DateTime DataNascimento { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
Seed Data: Popular a base de dados em memória com os dados do CSV fornecido e um usuário padrão.

## 2. Arquitetura Limpa

### Conceitos Fundamentais
Camadas: O projeto é dividido em várias camadas: entidades, casos de uso, interfaces e infraestrutura.

Dependências: As camadas internas não dependem das externas, garantindo um fluxo de dependência unidirecional.

### Benefícios
Manutenibilidade: Facilita a manutenção do código.

Testabilidade: A separação de responsabilidades facilita a criação de testes unitários.

Independência de Tecnologias: Pode-se trocar a infraestrutura sem afetar as camadas de domínio e aplicação.

### Diagrama

+-----------------+
|   Presentation   |
+--------+--------+
         |
+--------v--------+
|   Application    |
+--------+--------+
         |
+--------v--------+
|    Domain       |
+--------+--------+
         |
+--------v--------+
| Infrastructure  |
+-----------------+

## 3. Padrão Repository

### Objetivo
Abstrair o acesso aos dados, permitindo que a lógica de negócios não dependa de detalhes de implementação do mecanismo de persistência.

### Implementação
Criação de interfaces de repositório e suas implementações concretas.

### Benefícios
Abstração: Desacopla o código de negócio do mecanismo de persistência.

Testabilidade: Facilita a criação de testes unitários e de integração.

## 4. Estrutura de Pastas e Arquivos

Controllers: Recebem as requisições HTTP e retornam respostas.

Data: Contexto de dados, entidades e configurações do banco de dados.

Dtos: Objetos de transferência de dados entre camadas.

Models: Representam as entidades de domínio.

Services: Encapsulam a lógica de negócio e utilizam os repositórios.

Tests: Contêm testes unitários e de integração.

## Convenções de Nomenclatura
Seguem padrões de nomenclatura consistentes e descritivos para classes, métodos e arquivos.

# 5. Decisões de Design

Tecnologias e Frameworks: Escolha de .NET 6 e EF Core por sua robustez e integração com o ecossistema .NET.

Estrutura de Pastas: Organização clara e modular das pastas para facilitar a navegação e manutenção.

Implementação de Interfaces: Facilita a testabilidade e a substituição de implementações.

Tratamento de Erros: Implementação de middlewares de tratamento de erros para garantir respostas consistentes.

Padrões de Projeto: Uso de padrões como Repository para organizar o código.
