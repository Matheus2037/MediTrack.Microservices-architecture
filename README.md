# API de Sistemas de saúde

Este projeto foca no gerenciamento de informações de um hospital, permitindo o controle de médicos, pacientes e consultas. A aplicação permitirá que os administradores registrem informações sobre médicos e pacientes, agendem e atualizem consultas.
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
