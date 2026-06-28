# sistema-enderecos
Aplicação web desenvolvida em ASP.NET Core MVC para gerenciamento de endereços com autenticação de usuários.

# Funcionalidades

- Autenticação de usuário com login e senha
- CRUD completo de endereços (cadastrar, visualizar, editar e excluir)
- Busca automática de endereço por CEP via integração com a API do ViaCEP
- Exportação dos endereços para arquivo CSV

# Tecnologias Utilizadas

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core
- SQL Server
- BCrypt.Net (criptografia de senhas)
- Bootstrap 5
- JavaScript (Fetch API para integração com ViaCEP)

# Banco de Dados

O projeto utiliza Entity Framework com Migrations. As tabelas criadas são:

- **Usuarios** — Id, Nome, Login, Senha
- **Enderecos** — Id, Cep, Logradouro, Complemento, Bairro, Cidade, Uf, Numero, UsuarioId

# Pra Rodar o projeto:
- Necessario Visual Studio 2022 ou superior instalado
- SQL Server
- .NET 10 SDK

PASSO A PASSO
1. Clone o repositório
```bash
   git clone https://github.com/GabeTorresD/sistema-enderecos.git
```

2. Abra o arquivo `SistemaEnderecos.sln` no Visual Studio

3. Configure a string de conexão em `appsettings.json`:
```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=SistemaEnderecos;Trusted_Connection=True;TrustServerCertificate=True"
   }
```

4. No Console do Gerenciador de Pacotes, execute:
```powershell
   Update-Database
```

5. Rode o projeto com **F5**

### Credenciais padrão
- **Usuário:** admin
- **Senha:** admin123

#Grato pela oportunidade
