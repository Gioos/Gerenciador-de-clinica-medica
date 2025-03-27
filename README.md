# Gerenciador de clinica médica

Projeto de estudo em C# com API REST, Arquitetura Limpa, Padrão CQRS, Padrão Repository, Fluent Validation, Acesso à Dados com EF, Autorização e Autenticação com JWT e recuperação de senha com e-mail sendo enviado via SendGrid .

## 📌 Sobre o projeto  
O **Gerenciador** é uma aplicação backend desenvolvida em **C#**, seguindo **boas práticas de arquitetura** para garantir escalabilidade, organização e facilidade de manutenção.  

O sistema permite a **gestão de médicos, pacientes, atendimentos e serviços**, oferecendo um conjunto de operações CRUD e consultas eficientes.  Onde apenas usuário autenticado tem autorização para isso.

---

## 🛠️ Tecnologias e padrões utilizados  

- **C#** (.NET 8.0)  
- **API REST** com **ASP.NET Core**
- **Arquitetura Limpa**  
- **Padrão CQRS**
- **Fluent Validation**  
- **Entity Framework Core**  
- **SQL Server**
- **Autenticação e Autorização com JWT**
- **Recuperação de senha e Validação de código de acesso via e-mail com SendGrid**  



---

## 📂 Estrutura do Projeto  

- O projeto está organizado seguindo os princípios da Clean Architecture, com as seguintes camadas:

- API: Camada de apresentação, responsável por expor os endpoints da aplicação.

- Application: Contém a lógica de negócio e implementação do padrão CQRS (Commands e Queries).

- Domain: Camada de domínio, com as entidades e interfaces principais.

 - Infrastructure: Camada de infraestrutura, responsável por acesso a dados (Entity Framework), repositórios e configurações externas.

 ## 🔧 Funcionalidades  

✔️ **Médico**: CRUD + busca por **ID**  
✔️ **Paciente**: CRUD + busca por **ID** e **CPF**  
✔️ **Atendimento**: CRUD completo  
✔️ **Serviço**: CRUD completo  
✔️ Autenticação e Autorização 

✔️ Recuperação de senha com validação de código de acesso



