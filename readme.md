#Documenta��o do Projeto "UBC Gerenciador de Alunos API"

##1. Introdu��o
O objetivo deste projeto � desenvolver uma aplica��o web para gerenciar informa��es de estudantes, incluindo listagem, adi��o, atualiza��o e exclus�o de registros. A aplica��o � composta por uma WebAPI desenvolvida com .NET 6 e um front-end desenvolvido em React, incluindo uma tela de login.

Requisitos
Back-end (WebAPI)

Framework: .NET 6

Entity Framework: Usar o EF Core com um banco de dados em mem�ria

Autentica��o: Implementar autentica��o b�sica (JWT)

##Endpoints:

GET /api/students: Retorna todos os estudantes (autenticado)

GET /api/students/{id}: Retorna um estudante espec�fico (autenticado)

POST /api/students: Cria um novo estudante (autenticado)

PUT /api/students/{id}: Atualiza um estudante existente (autenticado)

DELETE /api/students/{id}: Deleta um estudante (autenticado)

POST /api/auth/login: Autentica um usu�rio e retorna um token JWT

##Modelo de Dados:

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
Seed Data: Popular a base de dados em mem�ria com os dados do CSV fornecido e um usu�rio padr�o.

##2. Arquitetura Limpa

###Conceitos Fundamentais
Camadas: O projeto � dividido em v�rias camadas: entidades, casos de uso, interfaces e infraestrutura.

Depend�ncias: As camadas internas n�o dependem das externas, garantindo um fluxo de depend�ncia unidirecional.

###Benef�cios
Manutenibilidade: Facilita a manuten��o do c�digo.

Testabilidade: A separa��o de responsabilidades facilita a cria��o de testes unit�rios.

Independ�ncia de Tecnologias: Pode-se trocar a infraestrutura sem afetar as camadas de dom�nio e aplica��o.

###Diagrama

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

##3. Padr�o Repository

###Objetivo
Abstrair o acesso aos dados, permitindo que a l�gica de neg�cios n�o dependa de detalhes de implementa��o do mecanismo de persist�ncia.

###Implementa��o
Cria��o de interfaces de reposit�rio e suas implementa��es concretas.

###Benef�cios
Abstra��o: Desacopla o c�digo de neg�cio do mecanismo de persist�ncia.

Testabilidade: Facilita a cria��o de testes unit�rios e de integra��o.

##4. Estrutura de Pastas e Arquivos

#Controllers: Recebem as requisi��es HTTP e retornam respostas.

#Data: Contexto de dados, entidades e configura��es do banco de dados.

#Dtos: Objetos de transfer�ncia de dados entre camadas.

#Models: Representam as entidades de dom�nio.

#Services: Encapsulam a l�gica de neg�cio e utilizam os reposit�rios.

##Tests: Cont�m testes unit�rios e de integra��o.

##Conven��es de Nomenclatura
Seguem padr�es de nomenclatura consistentes e descritivos para classes, m�todos e arquivos.

#5. Decis�es de Design

##Tecnologias e Frameworks: Escolha de .NET 6 e EF Core por sua robustez e integra��o com o ecossistema .NET.

##Estrutura de Pastas: Organiza��o clara e modular das pastas para facilitar a navega��o e manuten��o.

##Implementa��o de Interfaces: Facilita a testabilidade e a substitui��o de implementa��es.

##Tratamento de Erros: Implementa��o de middlewares de tratamento de erros para garantir respostas consistentes.

##Padr�es de Projeto: Uso de padr�es como Repository para organizar o c�digo.
