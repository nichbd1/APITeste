# Desafio Programador .NET Core ECS

## Premissas:
    - Projeto consiste em uma API REST, desenvolvida com .NET Core 3.1,
    que oferece endpoints de CRUD para as entidades Usuário e Repositório (Como se fosse o Github);
    - Você deve implementar endpoints relacionados a criação e consulta de Pull Requests para um repositório já existente;

## Etapas:
    - Implementar o método CreatePullRequest, que já tem seu esqueleto criado, dentro de RepositorioController;
    - Rota para essa requisição deve ser POST /repositorio/idRepositorio/pullrequest;
    - Corrigir retorno do método;
    - Endpoint deve receber, no body da requisição, os campos:
        ```
        {
            "FromBranch": "string",
            "ToBranch": "string",
            "Message": "string",
            "UsuarioId": integer
        }
        ```
		
        - FromBranch: a partir de qual branch está sendo feito o PR;
		- ToBranch: para qual branch está sendo feito o PR;
		- Message: mensagem colocada no PR;
		- UsuarioId: usuário que está fazendo o Pull Request.

    - Endpoint também deve receber o id do repositório onde está sendo feito o PR. Esse id estará presente na rota da requisição;
    - Com os dados da requisição já recebidos, deve-se validar, dentro do método CreatePullRequest, se o repositório onde está sendo feita a tentativa de Pull Request existe de fato. Caso não exista, deve-se gerar um erro informando que repositório não foi encontrado;
    - Validar se FromBranch é diferente de ToBranch. Caso sejam iguais, gerar erro informando que não é possível
    fazer pull request para a mesma branch de origem;
    - Se o repositório existir e FromBranch for diferente de ToBranch, deve-se criar de fato o Pull Request. Não se esqueça que um pull request é vinculado a algum repositório;

    - Para criar o Pull Request, será necessário a criação da entidade 'Pull Request' e configuração da mesma com Entity Framework.
    - Além além disso, também será necessário, de acordo com o padrão das demais funcionalidades já implementadas, a criação de arquivos
    nas camadas Services e Repositories (com Interface e implementação);
    - Crie o método que irá de fato realizar o insert do Pull Request no banco de dados;

    - Retornar o pull request criado;

    - Atente-se à utilização das camadas de serviço e repository, assim como seus respectivos contratos;
    - Tente seguir os padrões das demais funcionalidades que já estão desenvolvidas, entretanto
    faça as implementações da maneira como conseguir;
    - Concluíndo em tempo hábil, sinta-se à vontade para implementar outras funcionalidades que desejar.

### Observações

- As rotas devem seguir o padrão REST.
- Caso não seja possível concluir todas as tarefas, entregue o que foi desenvolvido e insira uma descrição sobre quais foram os impedimentos encontrados.
- O projeto utiliza AutoMapper, mas por praticiade somente. Sinta-se à vontade para não utilizar;
- Será necessário a utilização de injenção de dependências. Atente-se a isso.

### O que será avaliado
- Uso adequado de orientação a objetos;
- Lógica de programação;
- Utilização de boas práticas de programação;
- Capacidade de observar e seguir padrões de projeto.

## Configuração
- Certifique-se de ter um ambiente ASP NET Core configurado em sua máquina;
- Faça o clone do repositório;
- Execute um build na solution;
- Crie o banco de dados executando `Add-Migration 1.0.0.0` no Package Manager do Visual Studio;
- Após isso, execute o comando `Update-Database`;
    - Ao executar o projeto, as tabelas de Usuários, Tipo de Usuário e Repositório serão populadas com um registro inicial.
- Execute o projeto.
