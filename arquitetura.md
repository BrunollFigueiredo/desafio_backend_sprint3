# Arquitetura do Sistema de Gestão Acadêmica

## Visão Geral

API REST desenvolvida em ASP.NET Core 10 com arquitetura em camadas, banco de dados MySQL e autenticação via JWT.

---

## Estrutura de Camadas

```
Cliente (Swagger / Frontend)
        ↓
   Controllers        ← recebe as requisições HTTP
        ↓
    Services          ← contém as regras de negócio
        ↓
  Repositories        ← acessa o banco de dados
        ↓
  AppDbContext        ← Entity Framework Core
        ↓
   MySQL Database
```

### Controllers
Responsáveis por receber as requisições HTTP e retornar as respostas. Não contêm lógica de negócio. Delegam o processamento para os serviços.

- `AlunosController` — CRUD de alunos + endpoint de média
- `ProfessoresController` — CRUD de professores
- `DisciplinasController` — CRUD de disciplinas
- `NotasController` — listagem e lançamento de notas
- `AuthController` — autenticação e geração de token JWT

### Services
Contêm as regras de negócio da aplicação. Fazem a ponte entre os controllers e os repositórios.

- `AlunoService` — inclui cálculo de média e situação (Aprovado/Reprovado)
- `ProfessorService`
- `DisciplinaService`
- `NotaService`

### Repositories
Responsáveis exclusivamente pelo acesso ao banco de dados via Entity Framework Core.

- `AlunoRepository` — inclui carregamento das notas com disciplinas
- `ProfessorRepository` — inclui carregamento das turmas
- `DisciplinaRepository`
- `NotaRepository`

### DTOs (Data Transfer Objects)
Objetos usados para receber dados nas requisições, com validações via Data Annotations.

- `AlunoDTO` — Nome (obrigatório), Email (obrigatório, formato e-mail)
- `ProfessorDTO` — Nome (obrigatório), Email (obrigatório, formato e-mail)
- `DisciplinaDTO` — Nome (obrigatório), CargaHoraria (1 a 400)
- `NotaDTO` — AlunoId, DisciplinaId, Valor (0 a 10)
- `LoginDTO` — Usuario e Senha (obrigatórios)

---

## Banco de Dados

**SGBD:** MySQL 8.0  
**ORM:** Entity Framework Core 9 com Pomelo MySQL Provider

### Entidades e Relacionamentos

```
Aluno 1 ──── N Nota N ──── 1 Disciplina
Professor 1 ──── N Turma N ──── 1 Disciplina
```

| Tabela | Campos principais |
|---|---|
| Alunos | Id, Nome, Email |
| Professores | Id, Nome, Email |
| Disciplinas | Id, Nome, CargaHoraria |
| Notas | Id, AlunoId (FK), DisciplinaId (FK), Valor |
| Turmas | Id, Nome, ProfessorId (FK), DisciplinaId (FK) |

---

## Autenticação

Autenticação via **JWT (JSON Web Token)** com Bearer Token.

- Endpoint de login: `POST /api/Auth/login`
- Token expira em 2 horas
- Endpoints de escrita (POST, PUT, DELETE) exigem o token via header `Authorization: Bearer {token}`
- Endpoints de leitura (GET) são públicos

---

## Regra de Negócio

**Cálculo de Média:** `GET /api/Alunos/{id}/media`

Calcula a média aritmética de todas as notas do aluno e retorna a situação:
- Média >= 7.0 → **Aprovado**
- Média < 7.0 → **Reprovado**

---

## Documentação da API

Swagger disponível em `/swagger` com suporte a autenticação Bearer Token.

---

## Tecnologias Utilizadas

| Tecnologia | Versão |
|---|---|
| ASP.NET Core | 10.0 |
| Entity Framework Core | 9.0 |
| Pomelo MySQL Provider | 9.0 |
| JWT Bearer Authentication | 10.0 |
| Swashbuckle (Swagger) | 6.5 |
| MySQL Server | 8.0 |
