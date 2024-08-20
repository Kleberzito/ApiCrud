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
```json
[
    {
        "id": "guid",
        "nome": "Nome do Aluno"
    }
]
