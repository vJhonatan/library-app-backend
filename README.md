## Library App

API REST desenvolvida para gerenciar o aluguel de livros em uma biblioteca.

## Funcionalidades

- Listar todos os livros disponíveis no acervo.
- Consultar informações de um livro por ID.
- Alugar um livro por ID.
- Devolver um livro por ID do aluguel.
- Listar todos os registros de aluguéis.

## Tecnologias Utilizadas

- ASP.NET Core
- C#
- Swagger

## Endpoints

- **GET /api/books** - Lista todos os livros disponíveis.
- **GET /api/books/{id}** - Consulta o nome e a quantidade de um livro por ID.
- **POST /api/books/rent/{id}** - Aluga um livro específico pelo ID.
- **PUT /api/books/return/{rentalId}** - Realiza a devolução de um livro pelo ID do aluguel.
- **GET /api/books/rentals** - Lista todos os registros de aluguel.
