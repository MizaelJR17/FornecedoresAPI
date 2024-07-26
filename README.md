

---

# FornecedoresAPI

**FornecedoresAPI** é uma API RESTful desenvolvida usando ASP.NET Core que permite a gestão de fornecedores. Ela oferece operações para criar, ler, atualizar e excluir informações de fornecedores e inclui documentação interativa via Swagger.

## Índice

- [Descrição](#descrição)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Configuração do Projeto](#configuração-do-projeto)
- [Endpoints da API](#endpoints-da-api)
- [Como Executar](#como-executar)
- [Testes](#testes)
- [Documentação Swagger](#documentação-swagger)
- [Exemplos de Requisições](#exemplos-de-requisições)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Descrição

A **FornecedoresAPI** é uma aplicação para a gestão de fornecedores com os seguintes endpoints:

- **GET** `/api/fornecedores` - Obtém uma lista de todos os fornecedores.
- **GET** `/api/fornecedores/{id}` - Obtém um fornecedor específico pelo ID.
- **POST** `/api/fornecedores` - Adiciona um novo fornecedor.
- **PUT** `/api/fornecedores/{id}` - Atualiza um fornecedor existente.
- **DELETE** `/api/fornecedores/{id}` - Remove um fornecedor existente.

## Tecnologias Utilizadas

- **ASP.NET Core** - Framework principal para a construção da API.
- **Swashbuckle.AspNetCore** - Para geração da documentação Swagger.

## Configuração do Projeto

### Configuração do `appsettings.json`

Adicione as configurações necessárias no arquivo `appsettings.json`:

```json
{
  "TokenSettings": {
    "Token": "66a2f6ffd645e"
  }
}
```

## Endpoints da API

### `GET /api/fornecedores`

Obtém uma lista de todos os fornecedores.

**Resposta:**
- `200 OK` - Retorna a lista de fornecedores.
- `404 Not Found` - Nenhum fornecedor encontrado.
- `500 Internal Server Error` - Erro interno do servidor.

**Cabeçalhos:**
- `Authorization: Bearer 66a2f6ffd645e`

### `GET /api/fornecedores/{id}`

Obtém um fornecedor específico pelo ID.

**Parâmetros:**
- `id` (int) - ID do fornecedor a ser obtido.

**Resposta:**
- `200 OK` - Retorna o fornecedor com o ID especificado.
- `404 Not Found` - Fornecedor não encontrado com o ID especificado.
- `500 Internal Server Error` - Erro interno do servidor.

**Cabeçalhos:**
- `Authorization: Bearer 66a2f6ffd645e`

### `POST /api/fornecedores`

Adiciona um novo fornecedor.

**Corpo da Requisição:**

```json
{
  "id": 3,
  "nome": "TESTE1",
  "email": "user@example.com"
}
```

**Resposta:**
- `201 Created` - Fornecedor criado com sucesso.
- `400 Bad Request` - Dados do fornecedor inválidos.
- `500 Internal Server Error` - Erro interno do servidor.

**Cabeçalhos:**
- `Authorization: Bearer 66a2f6ffd645e`
- `Content-Type: application/json`

### `PUT /api/fornecedores/{id}`

Atualiza um fornecedor existente.

**Parâmetros:**
- `id` (int) - ID do fornecedor a ser atualizado.

**Corpo da Requisição:**

```json
{
  "id": 3,
  "nome": "TESTE Atualizado",
  "email": "user_updated@example.com"
}
```

**Resposta:**
- `204 No Content` - Fornecedor atualizado com sucesso.
- `400 Bad Request` - Incompatibilidade entre ID na URL e no corpo.
- `404 Not Found` - Fornecedor não encontrado com o ID especificado.
- `500 Internal Server Error` - Erro interno do servidor.

**Cabeçalhos:**
- `Authorization: Bearer 66a2f6ffd645e`
- `Content-Type: application/json`

### `DELETE /api/fornecedores/{id}`

Remove um fornecedor existente.

**Parâmetros:**
- `id` (int) - ID do fornecedor a ser removido.

**Resposta:**
- `204 No Content` - Fornecedor removido com sucesso.
- `404 Not Found` - Fornecedor não encontrado com o ID especificado.
- `500 Internal Server Error` - Erro interno do servidor.

**Cabeçalhos:**
- `Authorization: Bearer 66a2f6ffd645e`

## Como Executar

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/MizaelJR17/FornecedoresAPI.git
   ```

2. **Navegue para o diretório do projeto:**

   ```bash
   cd FornecedoresAPI
   ```

3. **Restaure as dependências:**

   ```bash
   dotnet restore
   ```

4. **Execute o projeto:**

   ```bash
   dotnet run
   ```

5. **Acesse a API no navegador:**

   - URL padrão: `http://localhost:5292/swagger`

## Testes

Para testar a API, você pode usar ferramentas como Postman ou cURL para enviar requisições para os endpoints descritos acima.

## Documentação Swagger

A documentação interativa do Swagger está disponível em:

- [Swagger UI](http://localhost:5292/swagger/index.html)

## Exemplos de Requisições

Aqui estão alguns exemplos de como usar a API com cURL:

### Obter todos os fornecedores

```bash
curl -X GET "http://localhost:5292/api/fornecedores" -H "Authorization: Bearer 66a2f6ffd645e"
```

### Obter um fornecedor específico

```bash
curl -X GET "http://localhost:5292/api/fornecedores/1" -H "Authorization: Bearer 66a2f6ffd645e"
```

### Adicionar um novo fornecedor

```bash
curl -X POST "http://localhost:5292/api/fornecedores" -H "Content-Type: application/json" -H "Authorization: Bearer 66a2f6ffd645e" -d '{
  "id": 3,
  "nome": "TESTE1",
  "email": "user@example.com"
}'
```

### Atualizar um fornecedor

```bash
curl -X PUT "http://localhost:5292/api/fornecedores/3" -H "Content-Type: application/json" -H "Authorization: Bearer 66a2f6ffd645e" -d '{
  "id": 3,
  "nome": "TESTE Atualizado",
  "email": "user_updated@example.com"
}'
```

### Remover um fornecedor

```bash
curl -X DELETE "http://localhost:5292/api/fornecedores/3" -H "Authorization: Bearer 66a2f6ffd645e"
```

## Contribuição

Se desejar contribuir para este projeto, sinta-se à vontade para enviar um pull request ou abrir uma issue com sugestões.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

![image](https://github.com/user-attachments/assets/f6946cd2-6c7a-4def-a351-fa47cf7bfc9e)


