# Biblioteca Virtual - Backend

Projeto para gerenciamento de locação de livros desenvolvido em .NET.

---

## Passos para Estruturação do Projeto

### 1. Organização do Projeto
- Crie a pasta **Models** para organizar os modelos de dados (Livro e Locação).
- Mantenha todos os endpoints no controlador principal, por exemplo, `BooksController`.

---

### 2. Modelagem dos Dados
#### Livro (`Book`):
- Deve conter as seguintes propriedades:
  - **Id**: Identificador único do livro.
  - **Título**: Nome do livro.
  - **Autor**: Nome do autor.
  - **Ano de Lançamento**: Ano de publicação.
  - **Quantidade**: Quantidade disponível.

#### Locação (`Rental`):
- Deve conter as seguintes propriedades:
  - **Id**: Identificador único da locação.
  - **Nome do Locatário**: Nome de quem alugou o livro.
  - **Ano de Nascimento**: Ano de nascimento do locatário.
  - **Id do Livro**: Identificador do livro alugado.
  - **Data da Locação**: Data em que o livro foi alugado.

---

### 3. Implementação no Controller
Implemente os endpoints diretamente no **BooksController**.

#### Lista de Endpoints:
- **`GET /books`**: Retorna todos os livros.
- **`GET /books/{id}`**: Retorna um livro específico pelo ID.
- **`POST /rentals`**: Registra a locação de um livro.
- **`PUT /rentals/return/{id}`** (opcional): Registra a devolução de um livro.

---

### 4. Regras de Negócio
Dentro do **BooksController**, implemente a lógica diretamente nos métodos:

#### Alugar Livro:
1. Verifique se há exemplares disponíveis antes de registrar a locação.
2. Reduza a quantidade do livro.
3. Retorne mensagens claras caso o livro esteja esgotado.

#### Devolver Livro (opcional):
1. Aumente a quantidade do livro ao registrar a devolução.

#### Consultar Livro:
1. Exiba somente livros com quantidade maior que 0 (opcional).

---

### 5. Dados em Memória
- Use uma lista inicial de livros, como a fornecida no PDF.
- Crie listas para armazenar as locações diretamente no controller.

---

### 6. Validações no Controller
Implemente as seguintes validações diretamente nos métodos:
1. Valide se o ID do livro existe.
2. Valide se o livro tem quantidade suficiente para locação.
3. Caso o livro não exista, retorne um erro **404 (Not Found)**.
