<h1 align="center">
  <span>MovieRank</span>
</h1>

<p align="center">
  <a href="#-projeto">Projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-configuracao">Configuração</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-utilizacao">Utilização</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-tecnologias">Estrutura do Projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-configuracao">Configuração</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#memo-licença">Licença</a>
</p>

<br>

<p align="center">
  <img alt="layout" src="./images/layout.gif" width="100%">
</p>

<br>

## 💻 Projeto

MovieRank é um projeto de exemplo que demonstra o uso do DynamoDB na AWS em conjunto com o .NET Core 6.

O projeto apresenta três modelos diferentes de acesso aos dados no DynamoDB: Object Persistence Model, Document Model e Low Level Model.


## 🚀 Tecnologias

Esse projeto foi desenvolvido com as seguintes tecnologias:

-   [TypeScript](https://www.typescriptlang.org/)
-   [React](https://pt-br.reactjs.org/)
-   [Styled Components](https://styled-components.com/)
-   [Vite](https://vitejs.dev/)
-   [Vercel](https://vercel.com/)

## 📥 Configuração

Para executar este projeto, é necessário ter uma conta na AWS e configurar suas credenciais no arquivo `appsettings.json`. Além disso, é necessário ter o SDK do .NET Core 6 instalado em sua máquina.

## Utilização

Ao executar o projeto, a API RESTful ficará disponível para uso em `http://localhost:5000` ou `https://localhost:5001` (se habilitado).

Os endpoints da API estão documentados e podem ser acessados através do Swagger em `http://localhost:5000/swagger/index.html`.

## Estrutura do projeto

O projeto está dividido em diferentes camadas:

- **Controllers**: camada responsável por lidar com as requisições HTTP e retornar as respostas adequadas.
- **Contracts**: camada que define os contratos da API.
- **Libs**: camada que contém as implementações de serviços e mappers que serão utilizados pelos controllers.
- **Models**: camada que define os modelos de dados utilizados no projeto.
- **Repositories**: camada que contém as implementações das classes responsáveis por lidar diretamente com o DynamoDB.
- **Services**: camada que contém as interfaces e implementações dos serviços utilizados pelos controllers.

## :memo: Licença

Esse projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE.md) para mais detalhes.

---

**Desenvolvido por [Bruno César](https://github.com/brunocs90).**
