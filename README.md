# FornecedoresAPI
Teste de Conhecimentos: Desenvolvimento de Web API em C# - Playmove

m C#

Instruções:
1. Você deve desenvolver uma Web API em C# utilizando ASP.NET Core para
listar fornecedores relacionados a uma empresa.
2. Utilize o banco de dados fornecido (FornecedoresDB) para armazenar e
consultar os dados.
3. Siga as melhores práticas de desenvolvimento de APIs RESTful.
4. Documente seu código adequadamente.
5. Ao finalizar, disponibilize o seu código pelo GitHub.
Tarefas:
1. Configuração Inicial:
o Crie um projeto de Web API em C# utilizando ASP.NET Core.
o Configure a conexão com o banco de dados (banco de dados da sua
escolha).
o Implemente as operações básicas de CRUD para a entidade Fornecedor
(listar todos os fornecedores, buscar fornecedor por ID, adicionar
fornecedor, atualizar fornecedor, excluir fornecedor).
2. Endpoints da API:
o Implemente os seguintes endpoints:
▪ GET /api/fornecedores: Retorna todos os fornecedores.
▪ GET /api/fornecedores/{id}: Retorna um fornecedor específico
pelo ID.
▪ POST /api/fornecedores: Adiciona um novo fornecedor.
▪ PUT /api/fornecedores/{id}: Atualiza um fornecedor existente
pelo ID.
▪ DELETE /api/fornecedores/{id}: Remove um fornecedor pelo ID.
3. Modelagem de Dados:
o Crie o modelo de dados Fornecedor com os seguintes atributos
mínimos:
▪ Id (int): Identificador único do fornecedor.
▪ Nome (string): Nome do fornecedor.
▪ Email (string): Endereço de e-mail do fornecedor.
▪ Outros campos relevantes conforme necessário.
4. Documentação:
o Utilize Swagger para documentar os endpoints da API.
 
Critérios de Avaliação:
• Conformidade com as instruções e requisitos especificados.
• Qualidade do código, seguindo as melhores práticas de desenvolvimento.
• Correta implementação das operações CRUD.
• Boas práticas de segurança e tratamento de erros.
• Eficiência e otimização no acesso ao banco de dados.
