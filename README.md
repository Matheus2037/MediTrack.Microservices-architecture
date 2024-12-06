# API de Sistemas de saúde

Este projeto foca no gerenciamento de informações de um hospital, permitindo o controle de médicos, pacientes e consultas. A aplicação permitirá que os administradores registrem informações sobre médicos e pacientes, agendem e atualizem consultas.

## Propósito do sistema: 
O sistema tem como objetivo gerenciar consultas médicas de forma eficiente, permitindo o agendamento, edição e exclusão de consultas, além de notificações automáticas para pacientes. Ele foi projetado para integrar diferentes serviços (clientes, doutores e consultas) através de microsserviços.  

## Quais são os usuários: 

* Os principais usuários do sistema são: 
* Administradores: Responsáveis pela gestão dos dados do sistema. 
* Doutores: Profissionais que realizam consultas médicas. 
* Pacientes: Pessoas que agendam e participam das consultas. 

## Requisitos funcionais: 

* Permitir o agendamento de consultas com validação de horário disponível. 
* Enviar notificações automáticas para pacientes sobre consultas agendadas. 
* Permitir a edição de consultas, alterando dados como horário, doutor ou paciente. 
* Implementar a exclusão de consultas, incluindo cancelamento de notificações associadas. 
* Garantir a consulta de informações de consultas por ID ou listagem geral. 
* Validar a disponibilidade do doutor e do cliente antes de confirmar o agendamento. 

## Microsserviços existentes:
Serviço de Consultas:

* Função: Gerencia as consultas médicas. Permite operações de criação, edição, exclusão e consulta de consultas.
* Tecnologias: .NET Core, Entity Framework, Hangfire para tarefas agendadas.
* Integração: Comunica-se com os serviços de doutores e pacientes para validação de dados.

Serviço de Doutores:

* Função: Mantém o cadastro de doutores, fornecendo informações sobre especialidades e disponibilidade.
* Tecnologias: .NET Core, SQLite.
* Integração: Responde a requisições do serviço de consultas sobre os doutores disponíveis.

Serviço de Pacientes:

* Função: Gerencia os dados dos pacientes. Oferece informações como histórico de consultas e dados de contato.
* Tecnologias: .NET Core, SQLite.
* Integração: Fornece informações ao serviço de consultas para validação e notificações.

## Executando

Para executar o projeto (sem Docker):

1. Execute os comandos de migrações nos diretórios das aplicações para preparar o banco de dados
Comandos:
 > dotnet ef migrations add NomeDaNovaMigracao
 > dotnet ef database update
2. Você pode configurar seu Visual Studio para executar os 3 serviços juntos apenas executando a solução da Consulta
 > ![image](https://github.com/user-attachments/assets/3a599761-b744-4b84-9a97-043876d35049)
 > ![image](https://github.com/user-attachments/assets/07be60a2-7990-42ba-b462-ffb0af306bed)

 

## Tecnologias Utilizadas

* .NET
* SQLite 
  

## Recursos

1. Doutor
2. Cliente
3. Consulta


## Rotas
Todas as rotas estão disponibilizadas com exemplos no Swagger de cada serviço, ao executar eles conforme foi mostrado nas imagens irá automaticamente abrir os 3.
