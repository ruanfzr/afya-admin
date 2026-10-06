# Afya Admin — Dashboard com Blazor WebAssembly e MudBlazor

## Identificação

| | |
|---|---|
| **Aluno(a)** | Ruan Moreira Ferreira |
| **Faculdade** | São Lucas Afya |
| **Curso** | Ciências da Computação |
| **Disciplina** | PROGRAMAÇÃO PARA SISTEMAS WEB |
| **Professor(a)** | LILUYOUD CURY DE LACERDA |
| **Semestre** | 2026.2 |

## Objetivo do projeto

O Afya Admin é um painel administrativo (dashboard) responsivo desenvolvido em Blazor WebAssembly (SPA) com a biblioteca MudBlazor. Seu objetivo é aplicar conceitos avançados de interfaces ricas, componentização e reatividade no ecossistema .NET.

A página principal (Dashboard.razor) consolida indicadores-chave (KPIs) como métricas financeiras, usuários ativos, vendas e conversão, utilizando filtros por período, gráficos interativos e tabelas estatísticas.

Com processamento total no navegador via WebAssembly, a aplicação garante alta performance, navegação fluida sem recarregamento e suporte nativo a temas claro e escuro.

## Tecnologias utilizadas

- .NET 10 / Blazor WebAssembly
- MudBlazor 9
- C# 13
- HTML5 & CSS3
- Git & GitHub

## Como executar

Pré-requisitos
.NET 10 SDK (ou superior) instalado na máquina.

Um navegador moderno compatível com WebAssembly (Chrome, Edge, Firefox, Brave, Safari).

Passo a passo para outra pessoa clonar e rodar o projeto:

```bash
git clone https://github.com/seu-usuario/afya-admin.git
cd afya-admin
dotnet watch
```
Após a compilação, o navegador abrirá automaticamente no endereço local http://localhost: e uma porta informada no terminal.


### HTML gerado (DevTools)
![Inspeção do HTML no DevTools]<img width="1567" height="407" alt="image" src="https://github.com/user-attachments/assets/e38d9e70-17fe-4bd2-9165-48b2bb3c52df" />


O print do DevTools mostra a inspeção do componente KpiCard (especificamente o cartão de Receita). O código C#/Blazor foi compilado e traduzido nas seguintes estruturas HTML e classes utilitárias do MudBlazor:

Componente inspecionado: KpiCard (Card de Receita exibindo "R$ 248.500").

HTML gerado: O contêiner principal do card renderizou uma tag <div> de superfície (MudPaper), enquanto o valor numérico em destaque foi traduzido em um elemento de título <h4>.

Classes utilitárias que apareceram:

Superfície e estrutura: mud-paper, mud-paper-outlined, pa-4 (padding de nível 4).

Alinhamento e Flexbox: d-flex, justify-space-between, align-center.

Tipografia e espaçamento: mud-typography, mud-typography-h4, font-weight-bold, mb-2 (margin-bottom) e mt-3 (margin-top).

Grid responsivo: mud-grid-item, mud-grid-item-xs-12, mud-grid-item-sm-6 e mud-grid-item-lg-3.

## Estrutura do projeto

Mostre a árvore de pastas e arquivos e explique em uma linha o papel de cada pasta (`Components`, `Data`, `Layout`, `Pages`, `wwwroot`).

afya-admin/
├── Components/         
├── Data/            
├── Layout/             
├── Pages/              
├── Properties/         
├── wwwroot/            
├── _Imports.razor      
├── App.razor           
├── Program.cs          
└── afya-admin.csproj   

Components/: Armazena componentes de interface reutilizáveis e customizados (ex: cards de estatísticas e seletores).

Data/: Contém as classes de modelo DTO/Entity e serviços de simulação de dados do dashboard.

Layout/: Define a casca visual da aplicação, como o menu de navegação lateral, barra superior e troca de tema.

Pages/: Guarda os componentes que possuem a diretiva @page e funcionam como telas acessíveis via rotas de URL.

wwwroot/: Concentra os ativos estáticos acessados diretamente pelo navegador, incluindo o index.html inicial.

## Componentes criados

| Componente | Responsabilidade | Parâmetros que recebe |
|---|---|---|
| `DashboardCard` | Contêiner genérico para blocos de conteúdo no painel, com suporte a título, ícone e conteúdo interno personalizável. | Title (string), Icon (string), ChildContent (RenderFragment) |
| `KpiCard` | Exibe cartões de métricas individuais com valor numérico, variação percentual, ícone e indicador de tendência. | Titulo (string), Valor (string), Variacao (double), Icone (string), Cor (Color) |
| `SeletorPeriodo` | Componente de formulário para seleção e filtragem do intervalo de datas/período dos dados exibidos no painel. | Valor (string), ValorChanged (EventCallback<string>) |

## O que aprendi

Responda **com suas próprias palavras** (um parágrafo curto por pergunta):

1. Como uma aplicação Blazor WebAssembly inicia no navegador? Qual é o papel do `index.html`, da `<div id="app">` e do `Program.cs`?
   
   Quando o usuário acessa o sistema, o navegador carrega primeiramente o arquivo wwwroot/index.html, que baixa o runtime do .NET compilado em WebAssembly (blazor.webassembly.js). A tag <div id="app"> serve como o elemento contêiner raiz onde toda a interface será injetada. O arquivo Program.cs é executado na inicialização client-side para registrar serviços no contêiner de injeção de dependência e instanciar o componente principal <App> dentro da div #app.
   
2. Qual é a diferença entre um **Layout**, uma **Page** e um **Component** neste projeto? Dê um exemplo de cada.
   
   Um Layout (MainLayout.razor) define a estrutura fixa e o enquadramento comum a várias telas (barra de topo, menu lateral e tema). Uma Page (Dashboard.razor) é uma tela completa associada a uma rota específica (@page "/"). Um Component (KpiCard.razor) é um bloco visual isolado e reutilizável que pode ser inserido dentro de páginas ou layouts para cumprir uma função específica.
   
3. O que é um `RenderFragment` e como o `DashboardCard` usa esse recurso para ser reutilizado por vários cards?
   
   O RenderFragment é um tipo de parâmetro no Blazor que representa um trecho de marcação UI/HTML passado de um componente pai para um filho. O DashboardCard declara um parâmetro chamado ChildContent do tipo RenderFragment. Isso permite que qualquer página envolva tabelas, gráficos ou textos dentro das tags do DashboardCard, reaproveitando o estilo estrutural do card enquanto altera livremente seu conteúdo interno.
   
4. Como funciona o `@bind-Valor` no `SeletorPeriodo`? Qual é o papel do `ValorChanged`?
   
   O @bind-Valor implementa a ligação bidirecional de dados (Two-Way Data Binding). Para que a sintaxe @bind-Valor funcione, o Blazor exige a conversão por convenção: o parâmetro de entrada Valor armazena o estado atual, enquanto o parâmetro ValorChanged (do tipo EventCallback<string>) dispara um evento para notificar o componente pai toda vez que a seleção do usuário muda, mantendo o estado sincronizado instantaneamente.
   
5. Por que os dados ficam na pasta `Data`, separados dos componentes? Que vantagem isso traz se, no futuro, os dados vierem de uma API?
    
   Essa separação segue o princípio da responsabilidade única (Single Responsibility Principle), isolando a lógica de apresentação da camada de dados. Se no futuro os dados do dashboard passarem a ser consumidos de um backend via REST API, bastará alterar as implementações dos serviços ou repositórios na pasta Data (injetando o HttpClient), sem a necessidade de modificar ou reescrever a lógica de interface das páginas e componentes.
   
6. Como o `MudGrid` com `xs`, `sm` e `lg` faz os cards de KPI se reorganizarem em telas de tamanhos diferentes?
    
   O MudGrid utiliza um sistema de grid responsivo de 12 colunas flexíveis baseado em breakpoints. Ao definir propriedades como xs="12" sm="6" lg="3" em um MudItem, determina-se que o card ocupará as 12 colunas (largura total) em dispositivos móveis (xs), 6 colunas (metade da tela, 2 por linha) em tablets (sm) e 3 colunas (1/4 da tela, 4 por linha) em monitores grandes (lg).
   
7. Como foi possível estilizar a página inteira sem escrever CSS? Explique o papel do tema (`MudTheme`) e das classes utilitárias.
    
   A estilização foi realizada inteiramente através do ecossistema do MudBlazor. O componente MudThemeProvider aplica um objeto MudTheme global contendo as definições de cores primárias, secundárias, tipografia e comportamento de iluminação (modo claro/escuro). O layout fino é ajustado por meio de classes utilitárias integradas (como pa-4 para padding e d-flex para flexbox), dispensando a escrita de arquivos .css customizados.
   
8. Por que o namespace do projeto é `afya_admin` e não `afya-admin`?
    
   Nas regras de sintaxe da linguagem C#, nomes de namespaces devem seguir os identificadores válidos do ecossistema .NET, os quais não permitem o uso de hífens (-), pois o hífen é interpretado pelo compilador como o operador aritmético de subtração. Por esse motivo, o nome do projeto afya-admin é convertido automaticamente para afya_admin utilizando underscore.
