# 🚀 SkillUp API – Plataforma de Evolução Profissional  
API desenvolvida para o projeto **SkillUp**, com objetivo de cadastrar usuários, registrar habilidades, associar cursos e gerar recomendações personalizadas.

Projeto desenvolvido em **.NET 9 + Entity Framework Core + SQLite**, com estrutura em camadas (Api + Infrastructure).

---

## 👥 Integrantes do Grupo

- **João Pedro Do Vale Cruz Novo** – RM **98650**
- **Victor Eid Carbutti Nicolas** – RM **98668**
- **Tiago Rafael Paulino Ferreira** – RM **551169**

---

## 🔧 Tecnologias Utilizadas

- **.NET 9**
- **ASP.NET Core Web API**
- **Entity Framework Core 9**
- **SQLite**
- **Swagger / OpenAPI**
- **Arquitetura em camadas (API + Infrastructure)**

---

## 📁 Estrutura do Projeto

SkillUp/
├── SkillUp.Api
│ ├── Controllers
│ ├── DTOs
│ ├── Program.cs
│ └── appsettings.json
│
├── SkillUp.Infrastructure
│ ├── Data
│ ├── Entities
│ ├── Migrations
│ └── Repositories
│
└── SkillUp.sln

---

## ▶️ Como Executar o Projeto

### 1. Restaurar dependências

dotnet restore

A API será iniciada em:

👉 **http://localhost:5081**

Swagger disponível em:

👉 **http://localhost:5081/docs**

---

## 📌 Endpoints Principais

### 👤 Usuários
| Método | Endpoint | Descrição |
|--------|-----------|-----------|
| **POST** | `/api/v1.0/users` | Cria um novo usuário |
| **GET** | `/api/v1.0/users/{id}` | Busca usuário pelo ID |

---

### 🎯 Habilidades (Skills)
| Método | Endpoint | Descrição |
|--------|-----------|-----------|
| **POST** | `/api/v1.0/users/{id}/skills` | Adiciona uma skill ao usuário |
| **PUT** | `/api/v1.0/users/{id}/skills/{skillId}` | Atualiza nível de uma skill existente |

---

### 📚 Cursos
| Método | Endpoint | Descrição |
|--------|-----------|-----------|
| **GET** | `/api/v1.0/courses` | Lista todos os cursos disponíveis |
| **POST** | `/api/v1.0/courses` | Adiciona um novo curso na plataforma |

---

### 🤖 Recomendações
| Método | Endpoint | Descrição |
|--------|-----------|-----------|
| **GET** | `/api/v1.0/recommendations/{userId}` | Retorna cursos recomendados com base nas skills e objetivo do usuário |

---


## 🧩 Fluxograma da Arquitetura

![Fluxograma](https://github.com/user-attachments/assets/7b508b1c-8da5-4fd0-b2b1-fed2b7e8070a)

---

## 🎥 Demonstração em Vídeo

Assista à apresentação completa da solução no YouTube:

👉 **[Clique aqui para ver o vídeo](https://www.youtube.com/watch?v=PQnbezFZEPA)**  







