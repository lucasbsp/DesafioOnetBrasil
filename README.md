# Desafio Onet Brasil

## Sobre o Desafio

Esse desafio tem como objetivo a demonstração de conhecimento técnico sobre o framework .NET MAUI, e será utilizado como parte do processo seletivo da empresa Onet Brasil para a vaga de desenvolvedor.

## Sobre o Desenvolvedor / Participante do Processo Seletivo

O perfil profissional do desenvolvedor pode ser encontrado no LinkedIn pelo nome "lucasbaptistadesenvolvedor", ou [clicando aqui](https://www.linkedin.com/in/lucasbaptistadesenvolvedor/).
<br>
O desenvolvedor ("Lucas Baptista") é o único responsável pela criação e manutenção deste repositório.

## Sobre o Projeto

Desenvolver um aplicativo para dispositivo móvel que contenha uma lista de tarefas simples.
Utilize o framework MAUI (Multi-platform App UI). O aplicativo deve permitir que os usuários criem,
visualizem, editem e excluam tarefas.

## Requisitos Técnicos

### Utilização do framework .NET MAUI

Foi utilizada a versão 8.0.40 do framework .NET MAUI.

### Um padrão de design moderno 

O padrão de design escolhido para esse projeto é o MVVM (Model, View, ViewMoodel).
<br>
Para mais detalhes sobre este padrão, [clique aqui](https://learn.microsoft.com/pt-br/dotnet/maui/xaml/fundamentals/mvvm?view=net-maui-8.0).

### Banco de dados local

O banco de dados escolhido para esse projeto foi o SQLite, por ser um banco offline, simples e poderoso.

### Aplicativo funcional e intuitivo

A interface foi desenvolvida para ser simples e de fácil entendimento para todos os públicos, seguindo os padrões de design de aplicativos móveis já consolidados pelo mercado.

## Ambiente de Desenvolvimento

Essa aplicação foi desenvolvida com as seguintes configurações e ferramentas:
- Visual Studio Community 2022 (64-bit), versão 17.9.7
- Emulador Android 14.0 - API 34 - Processador x86_64 - Memória 1GB
- .NET 8.0 (Long Term Support)

## O Aplicativo

O aplicativo é composto por duas telas:
- Listagem de tarefas
- Criação / edição de tarefas

As telas de Crição e Edição são as mesma, e foi adotado esse modelo pois em um ambiente de produção isso resulta em uma manutenção mais rápida e eficiente ao longo prazo.

### Tela de listagem de tarefas

| Lista Preenchida	| Lista Vazia       |
|------------------	|-----------------	|
| ![Screenshot_1716179500](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/8a173501-9659-4f67-ab98-49ddc7bbd880)                 	| ![Screenshot_1716229166](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/c1e3358f-5f27-4fff-b1b8-36764bfa3510)                	|

### Tela de criação / edição de tarefas

| Criação de Tarefas 	  | Edição de Tarefas 	|
|---------------------	|--------------------	|
| ![Screenshot_1716179535](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/568eacec-518f-43c1-96de-0694a618db60)                 	| ![Screenshot_1716179506](https://github.com/lucasbsp/DesafioOnetBrasil/assets/30881240/c4716a5d-9178-40a7-81cf-9de80ab0853c)                	|
