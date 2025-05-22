# iBike Backend


**Backend da plataforma iBike — monitoramento inteligente de pátios de motos**

## Integrantes

| Nomes | RM                  |  
| ----------- | -------------------------- | 
| `Gabriel Dias Menezes`      | `555019`       
| `Júlia Soares Farias Dos Santos`  | `554609`       |

## 🛠️ Sobre o Projeto

O **iBike Backend** é a API responsável pela gestão da plataforma iBike, que monitora pátios de motocicletas conectando dados de motos, funcionários (administradores), pátios e eventos de monitoramento.

A plataforma facilita o controle do status das motos e da ocupação dos pátios, com eventos detalhados de entrada e saída. Os dados de monitoramento são simulados via integração com o MockAPI da Mottu, replicando dados externos reais.

---

## 🎯 Funcionalidades

* **Gerenciamento de Administradores**
  Funcionários que gerenciam os pátios, com autenticação e autorização para acesso e modificação apenas dos seus próprios dados.

* **Controle de Motos**
  Cadastro, atualização e visualização das motos, filtrando por status e local de pátio.

* **Gestão de Pátios**
  Monitoramento da capacidade e status (disponível, cheio, sobrecarregado) dos pátios.

* **Eventos de Monitoramento**
  Registro dos eventos de entrada e saída das motos, permitindo rastreamento do fluxo.

* **Segurança JWT**
  Acesso seguro usando tokens JWT para autenticação e controle de permissão.
* **Cache para Performance**
  Cache de dados frequentes para otimizar consultas.

---

## 📁 Estrutura do Projeto


---

## 🔁 Rotas da API 

### 🔐Administradores

| Método HTTP | Rota                       | Descrição                                   | Corpo da Requisição (`JSON`)                                                                                                | Resposta Esperada                           |
| ----------- | -------------------------- | ------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| `POST`      | `/api/administrador`       | Cria um novo administrador                  | `{ "cpf": "12345678901", "nome": "João", "email": "joao@ex.com", "password": "senha123", "status": "ATIVO", "patioId": 1 }` | `201 Created` ou `400 Bad Request`          |
| `GET`       | `/api/administrador`       | Lista todos os administradores              | —                                                                                                                           | Lista de administradores (`200 OK`)         |
| `GET`       | `/api/administrador/{cpf}` | Retorna um administrador específico por CPF | —                                                                                                                           | Administrador (`200 OK`) ou `404 Not Found` |
| `PUT`       | `/api/administrador/{cpf}` | Atualiza dados de um administrador pelo CPF | Mesmo formato do `POST`, mas com campos atualizados                                                                         | `200 OK` ou `404 Not Found`                 |
| `DELETE`    | `/api/administrador/{cpf}` | Remove um administrador do sistema          | —                                                                                                                           | `204 No Content` ou `404 Not Found`         |


### 🏍️ Motos

| Método HTTP | Rota                | Descrição                             | Corpo da Requisição (`JSON`)                                                                                                                      | Resposta Esperada                   |
| ----------- | ------------------- | ------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------- |
| `POST`      | `/api/moto`         | Cadastra uma nova moto                | `{ "placa": "ABC1234", "modelo": "Honda CG 160", "status": "EM_USO", "kmAtual": 1500.5, "dataUltimoCheck": "2025-05-20T14:30:00", "patioId": 2 }` | `201 Created` ou `400 Bad Request`  |
| `GET`       | `/api/moto`         | Lista todas as motos                  | —                                                                                                                                                 | Lista de motos (`200 OK`)           |
| `GET`       | `/api/moto/{placa}` | Retorna uma moto específica por placa | —                                                                                                                                                 | Moto (`200 OK`) ou `404 Not Found`  |
| `PUT`       | `/api/moto/{placa}` | Atualiza os dados de uma moto         | Mesmo corpo do `POST`, com valores atualizados                                                                                                    | `200 OK` ou `404 Not Found`         |
| `DELETE`    | `/api/moto/{placa}` | Remove uma moto do sistema            | —                                                                                                                                                 | `204 No Content` ou `404 Not Found` |

### 🏢 Pátios

| Método HTTP | Rota            | Descrição                                                          | Corpo da Requisição (`JSON`)                                       | Resposta Esperada                                                           |
| ----------- | --------------- | ------------------------------------------------------------------ | ------------------------------------------------------------------ | --------------------------------------------------------------------------- |
| `GET`       | `/patio`        | Lista todos os pátios                                              | —                                                                  | Lista de pátios (`200 OK`)                                                  |
| `GET`       | `/patio/{id}`   | Retorna um pátio específico pelo ID                                | —                                                                  | Pátio (`200 OK`) ou `{ "message": "Pátio não encontrado" } (404 Not Found)` |
| `GET`       | `/patio/filtro` | Filtra pátios por status (`status=ATIVO` ou `status=INDISPONIVEL`) | — (apenas query param `status`)                                    | Lista de pátios filtrados (`200 OK`)                                        |
| `POST`      | `/patio`        | Cria um novo pátio                                                 | `{ "nome": "Brooklin", "capacidade": 45, "status": "DISPONIVEL" }` | `201 Created` com o objeto criado ou `400 Bad Request`                      |

### 📈 Monitoramentos

| Método HTTP | Rota                      | Descrição                               | Corpo da Requisição (`JSON`)                        | Resposta Esperada                    |
| ----------- | ------------------------- | --------------------------------------- | --------------------------------------------------- | ------------------------------------ |
| `POST`      | `/api/monitoramento`      | Cria um evento de monitoramento         | `{ "tipoEvento": "SAIDA", "motoPlaca": "ABC1234" }` | `201 Created` ou `400 Bad Request`   |
| `GET`       | `/api/monitoramento`      | Lista todos os eventos de monitoramento | —                                                   | Lista de eventos (`200 OK`)          |
| `GET`       | `/api/monitoramento/{id}` | Retorna evento de monitoramento por ID  | —                                                   | Evento (`200 OK`) ou `404 Not Found` |

---

## ⚙️ Tecnologias Utilizadas

| Tecnologia                             | Finalidade                                  |
| -------------------------------------- | ------------------------------------------- |
| C# (.NET 8)                            | Linguagem principal e framework web backend |
| ASP.NET Core                           | Framework para construção da API REST       |
| Entity Framework Core                  | ORM para manipulação do banco de dados      |
| SQL Server / H2                        | Banco de dados (desenvolvimento e produção) |
| Swagger / Swashbuckle                  | Documentação interativa da API              |
| AutoMapper                             | Conversão entre entidades e DTOs            |
| Serilog / ILogger                      | Log e monitoramento                         |
| REST Client (Thunder Client / Postman) | Testes de endpoints                         |


## 🚀 Como Rodar o Projeto

Siga os passos abaixo para executar a aplicação localmente em sua máquina:

1. **Clone o repositório**

   ```bash
   git clone https://github.com/gabrieldiasmenezes/ibikeNet.git
   ```
   
---

2. **Acesse a pasta do projeto**

   ```bash
   cd ibikeNet
   ```
---

3. **Restaure as dependências**

   ```bash
   dotnet restore
   ```
---

4. **Compile e execute o projeto**

   ```bash
   dotnet run
   ```
---

5. **Acesse a API no navegador**

Após o projeto iniciar, abra o navegador e acesse:
   ```bash
   https://localhost:{porta}/swagger
   ```
---

6. **Teste os endpoints**

   ```bash
   Utilize o Swagger UI (documentação interativa gerada automaticamente) ou ferramentas como Postman ou Thunder Client para testar as rotas da API.
   ```


   







































