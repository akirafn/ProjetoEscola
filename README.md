# ProjetoEscola
Projeto web para gerência de escola. Possui 2 telas disponíveis.
- **Estudantes**, trazendo a relação de todos os estudantes cadastrados, sendo possível filtrar por série e classe.
- **Professores**, trazendo a relação de todos os professores cadastrados, as matérias lecionadas bem como as séries e classes nas quais lecionam.

#Estrutura do projeto
O projeto está dividido em 2 subprojetos: API e Front.

## API
Responsável por efetuar consultas no banco de dados e realizar operações de CRUD.
Foi elaborado na arquitetura MVC em linguagem C#, sendo assim composto por 3 pastas principais:
- **Models**, contendo todos os modelos utilizados para transmissão das informações entre serviço e interface;
- **Services**, contendo as classes que realizam interface diretamente com o banco de dados, consultando e realizando as operações necessárias;
- **Controllers**, que constituem da interface da API, responsáveis por intermediar as chamadas e retornar os dados dos serviços em formato JSon. Todas as chamadas de consulta são POST, enquanto as chamadas de manipulação são em POST.

##Front
Responsável pelas telas de acesso do usuário. Todas as informações exibidas são carregadas a partir das chamadas ao projeto API.
Também foi elaborada seguindo a arquitetura MVC, assim sendo composta por 3 pastas principais:
- **Models**, contendo todos os modelos utilizados para transmissão das informações entre serviço e interface;
- **Services**, contendo as classes que realizam chamada diretamente para a API, intermediando as traduções de JSon para os modelos de dados utilizados no projeto;
- **Pages**, contendo as telas de interface diretamente com o usuário. Foi elaborado em Blazor.

#Banco de Dados
O banco de dados utilizado foi SQL-Server, com uma base disposta localmente. Os scripts das tabelas bem como os dados inseridos inicialmente estão disponibilizados na pasta Scripts.