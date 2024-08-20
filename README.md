# Documentação da API Minimal .NET com SQL Server

## Descrição
Esta API minimal em .NET foi desenvolvida para gerenciar o cadastro de alunos, utilizando o SQL Server como banco de dados. A API segue o padrão CRUD (Create, Read, Update, Delete) e todas as requisições são assíncronas. A aplicação trata três características principais para cada aluno:

- **ID**: Identificador único (GUID)
- **Nome**: Nome do aluno (string)
- **Status Ativo**: Indicador de atividade do aluno (bool)

## Endpoints

### 1. Obter lista de alunos ativos

**GET** `/estudante`

#### Descrição
Este endpoint retorna uma lista de alunos cujo status ativo é `true`.

#### Retorno
````json
[
    {
        "id": "guid",
        "nome": "Nome do Aluno"
    }
]
````

### 2. Criar um novo aluno

**POST** `/estudante`

#### Descrição
Este endpoint cria um novo aluno no banco de dados. O status ativo é definido automaticamente como true para todos os novos registros.

#### Exemplo de Requisição

````json
[
    {
        "nome": "Nome do Aluno"
    }
]
````

#### Retorno
````json
[
    {
        "id": "guid",
        "nome": "Nome do Aluno"
    }
]
````

### 3. Atualizar o nome de um aluno

***PUT*** `/estudante/{id}`

#### Descrição
Este endpoint permite a atualização do nome de um aluno específico, identificado pelo seu ID.

#### Exemplo de Requisição
A requisição deve incluir o novo nome do aluno, junto com o ID na URL.

````json
[
    {
        "nome": "Nome do Aluno"
    }
]
````

#### Retorno
````json
[
    {
        "id": "guid",
        "nome": "Novo Nome do Aluno"
    }
]
````

### 4. Desativar um aluno (soft delete)
***DELETE*** `/estudante/{id}`

#### Descrição
Este endpoint realiza a desativação de um aluno, alterando o status ativo para false. O aluno não é removido do banco de dados, apenas marcado como inativo.

#### Exemplo de Requisição
A requisição deve incluir o ID do aluno na URL. Não é necessário enviar um corpo (body) na 

#### Retorno
````json
[
    {
        "id": "guid",
        "nome": "Nome do Aluno"
    }
]
````
