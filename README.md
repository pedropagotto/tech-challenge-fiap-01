![CI](https://github.com/pedropagotto/tech-challenge-fiap-01/actions/workflows/ci.yml/badge.svg)
# Tech Challenge FIAP 01

# Integrantes:

👨‍💻 RM 356893 - Pedro Ernesto Pagotto

👨‍💻 RM 357001 - Rogerio da Silva Souza

👨‍💻 RM 357298 - Sérgio Fleury Dias Filho


To-do
Criar/importar a massa para testes do banco

Script
Apresentar o Miro - DDD (Event storming e blablabla)
Overview das escolhas tecnicas (postgres, docker, EFCore ORM)
Apresentar a arquitetura/estrutura do projeto (projeto em camadas, middleware de exceções)
Falar sobre os pacotes instalados (automapper, xunit, bogus, fluentassertions, fluentvalidation, JWT, Moq)
Mostrar as tabelas criadas via migration
Mostrar e rodar os testes (mostrar o codecoverage)
Mostrar o Swagger e os endpoints
Tentar bater em algum endpoint para mostrar o erro 401
Autenticar com algum usuario admin no endpoint de login
Mostrar erros de validação ao criar novo usuário (email, ddd, nome, telefone)
{
"name": "S",
"ddd": "a1",
"phone": "981a5-4567",
"email": "sanders.vieira"
}
Criar um contato
Listar todos
Listar com query de DDD
Listar por Id (existente e inexistente (confirmar o 404))
Mostrar o Put alterando o DDD e mostrar no getbyid que alterou
Mostrar o delete de um contato




# Techs Utilizadas:

✅ - .NET 8 (Web Api)

✅ - Banco de dados Postgres


# Ferramentas:
🎈 - [Miro](https://miro.com/app/board/uXjVKwg7ktM=/?share_link_id=761946195858)

🎈 -  Github


# Para  iniciar o banco:

Inicie o docker em sua maquina, navegue até a pasta do projeto via terminal e execute o comando abaixo:

```shell
docker compose up
```
