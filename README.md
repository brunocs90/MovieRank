<h1 align="center">
  <span>MovieRank</span>
</h1>
<p align="center">
  <a href="#-projeto">Projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-configuração">Configuração</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-estrutura">Estrutura</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-licença">Licença</a>
</p>
<br>
<p align="center">
  <img alt="layout" src="./images/layout.gif" width="100%">
</p>
<br>

## 🚀 Projeto


MovieRank é um projeto de exemplo que demonstra o uso do DynamoDB na AWS em conjunto com o .NET Core 6.
O projeto apresenta três modelos diferentes de acesso aos dados no DynamoDB: Object Persistence Model, Document Model e Low Level Model.


## 💻 Tecnologias

Esse projeto foi desenvolvido com as seguintes tecnologias:

- .NET Core 6.0: plataforma de desenvolvimento de software livre e multiplataforma, utilizada para criar aplicativos modernos para a Web, desktop e dispositivos móveis.
- Amazon DynamoDB: um serviço de banco de dados NoSQL gerenciado oferecido pela Amazon Web Services (AWS).
- Entity Framework Core: um framework ORM (Object-Relational Mapping) que permite o acesso a bancos de dados relacionais por meio de objetos e classes do C#.
- Swashbuckle.AspNetCore: um pacote para geração automática de documentação do Swagger/OpenAPI para APIs ASP.NET Core.
- Moq: uma biblioteca de mocking para testes unitários em .NET.
- xUnit: um framework de teste unitário para .NET Core.
- FluentAssertions: uma biblioteca para escrever testes mais expressivos em .NET.
- AWS SDK for .NET: uma biblioteca para interagir com serviços da AWS na plataforma .NET.

## 📥 Configuração

Para executar este projeto, é necessário ter uma conta na AWS e configurar suas credenciais no arquivo `appsettings.json`. Além disso, é necessário ter o SDK do .NET Core 6 instalado em sua máquina.

Ao executar o projeto, a API RESTful ficará disponível para uso em `http://localhost:5000` ou `https://localhost:5001` (se habilitado).
Os endpoints da API estão documentados e podem ser acessados através do Swagger em `http://localhost:5000/swagger/index.html`.

## 🏗️ Estrutura

O projeto está dividido em diferentes camadas:

- **Controllers**: camada responsável por lidar com as requisições HTTP e retornar as respostas adequadas.
- **Contracts**: camada que define os contratos da API.
- **Libs**: camada que contém as implementações de serviços e mappers que serão utilizados pelos controllers.
- **Models**: camada que define os modelos de dados utilizados no projeto.
- **Repositories**: camada que contém as implementações das classes responsáveis por lidar diretamente com o DynamoDB.
- **Services**: camada que contém as interfaces e implementações dos serviços utilizados pelos controllers.

## 📝 Licença

Esse projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE.md) para mais detalhes.

---

**Desenvolvido por [Bruno César](https://github.com/brunocs90).**
