# Desafio Onet Brasil

## Conteúdo

1. [Sobre o Desafio](#Sobre-o-Desafio)
2. [Sobre o Desenvolvedor / Participante do Processo Seletivo](#sobre-o-desenvolvedor--participante-do-processo-seletivo)
3. [Sobre o Projeto](#sobre-o-projeto)
4. [Requisitos Técnicos](#requisitos-técnicos)
5. [Sobre o Aplicativo](#sobre-o-aplicativo)
6. [Comunicação com o Usuário](#comunicação-com-o-usuário)
7. [Tratamento de Erros](#tratamento-de-erros)
8. [Ambiente de Desenvolvimento](#ambiente-de-desenvolvimento)

## Sobre o Desafio

Esse desafio tem como objetivo a demonstração de conhecimento técnico sobre o framework .NET MAUI, e será utilizado como parte do processo seletivo da empresa Onet Brasil para a vaga de desenvolvedor.


## Sobre o Desenvolvedor / Participante do Processo Seletivo

O perfil profissional do desenvolvedor pode ser encontrado no LinkedIn pelo nome "**lucasbaptistadesenvolvedor**", ou [clique aqui](https://www.linkedin.com/in/lucasbaptistadesenvolvedor/).
<br>
O desenvolvedor ("**Lucas Baptista**") é o responsável pela criação e manutenção deste repositório.


## Sobre o Projeto

Desenvolver um aplicativo para dispositivo móvel que contenha uma lista de tarefas simples.
Utilize o framework MAUI (Multi-platform App UI). O aplicativo deve permitir que os usuários criem,
visualizem, editem e excluam tarefas.


## Requisitos Técnicos

### Utilização do framework .NET MAUI

Versão utilizada:

> .NET MAUI 8.0.40

### Um padrão de design moderno 

O padrão de design escolhido para esse projeto é o **MVVM** (Model, View, ViewMoodel).<br>
Ele foi estruturado da seguinte forma:

> /**Models**: Contém as classes de modelo do SQLite.<br>
> /**Views**: Contém as páginas de interface do usuário.<br>
> /**ViewModels**: Contém as classes de lógica de apresentação.<br>
> /**Services**: Contém os serviços para interação com o banco de dados.

[Clique aqui](https://learn.microsoft.com/pt-br/dotnet/maui/xaml/fundamentals/mvvm?view=net-maui-8.0) para acessar a documentação da Microsoft sobre o MVVM em projetos .NET MAUI.

### Banco de dados local

O banco de dados escolhido para esse projeto foi o **SQLite**, por ser um banco offline, simples e poderoso.<br>
Sua implementação foi realizada pelo seguinte plugin:

> SQLite-NET-PCl v1.9.172

### Aplicativo funcional e intuitivo

A interface foi desenvolvida para ser simples e de fácil entendimento para todos os públicos, seguindo os padrões de design de aplicativos móveis já consolidados pelo mercado.


## Sobre o Aplicativo

O aplicativo é composto por duas telas:
- Listagem de tarefas
- Criação / edição de tarefas

### Tela de listagem de tarefas

| Lista Preenchida	| Lista Vazia       |
|------------------	|-----------------	|
| ![Lista Preenchida](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/1f34a236-a18a-406e-a052-a7213615650f)                 	| ![Lista Vazia](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/29f2ec6a-d745-4581-bfaf-1d4cab1cdf61)                	|

#### Campos da tela:

- Título da tarefa
- Descrição da tarefa
- Data de atualização da tarefa
- Status da tarefa
- Botões de ação: editar / excluir

> Para evitar que a tela fique poluída com muita informação, o **título** possui um limite de exibição de conteúdo de 1 linha, e a **descrição** possui um limite de 2 linhas.

#### Ordem de exibição:

As tarefas podem ser ordenadas por:
- Data de cadastro (Padrão)
- Data de atualização
- Status
- Nome

Cada uma dessas opções podem ser ordenadas de forma ascendente ou descendente.

### Tela de criação / edição de tarefas

| Criação de Tarefas    | Edição de Tarefas 	|
|---------------------	|--------------------	|
| ![Criação de Tarefas](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/568eacec-518f-43c1-96de-0694a618db60)                 	| ![Edição de Tarefas](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/c4716a5d-9178-40a7-81cf-9de80ab0853c)                	|


#### Campos da tela:

- Título da tarefa: limite de 100 caracteres
- Descrição da tarefa: limite de 250 caracteres
- Status da tarefa: Completo / Incompleto
- Botões de ação: salvar / excluir / voltar

> A mesma tela é utilizada para a _crição_ e _edição_ de tarefas, e foi adotado esse modelo pois em um ambiente de produção isso resulta em uma manutenção mais rápida e eficiente ao longo prazo.

## Comunicação com o Usuário

Informar ao usuário o que está acontecendo e exibir mensagens de confirmação ao realizar uma ação é algo muito importante, dessa maneira podemos alinhar as espectativas do usuário com o aplicativo e evitar frustrações.<br>
Ao criar ou alterar uma tarefa, o usuário recebe a confirmação de sua respectiva ação:

![Tarefa criada com sucesso!](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/15deef51-e9cf-495a-88d5-bf0c48af5d56)

![Tarefa atualizada com sucesso!](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/ce8d9ac1-737c-43d5-94db-6de8a07cbfa3)

![Campo obrigatório: Título](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/d7e28f3a-0d5a-4c92-aacc-32bfebe11750)

![Campo obrigatório: Status da Tarefa](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/31077c4a-1b1a-41f2-bc87-06144ca9c5a3)

## Tratamento de Erros

Recomenda-se sempre ter um controle dos logs de erro e um nível mínimo de auditoria dos dados. Considerando o escopo e objetivos do projeto, foi optado por não persistir os dados de erros, embora o aplicativo realize o tratamento dos dados quando há algum erro, ele exibe uma mensagem amigável, com o objetivo de informar sem causar frustações ou assustar o usuário.

### Exemplo de erro amigável

![Screenshot_1716269304](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/cbad266f-959b-4cdc-9075-898c2432ae38)

## Ambiente de Desenvolvimento

Essa aplicação foi desenvolvida com as seguintes configurações e ferramentas:
- Visual Studio Community 2022 (64-bit), versão 17.9.7
- Emulador Android 14.0 - API 34 - Processador x86_64 - Memória 1GB
- .NET 8.0 (Long Term Support)
