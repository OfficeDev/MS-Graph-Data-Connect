---
page_type: sample
products:
- office-365
- ms-graph
languages:
- csharp
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  services:
  - Office 365
  - Microsoft Graph data connect
  createdDate: 2/6/2018 9:50:48 AM
---
# Conexão de dados do Microsoft Graph
#### Usando os dados do Office 365 com o Azure Analytics para criar aplicativos inteligentes 

## Introdução 

O Microsoft Graph Data Connect exibe dados do Office 365 e recursos do Azure a ISVs (fornecedores independente de software). Este sistema permite aos ISVs criar aplicativos inteligentes com os dados mais valiosos da Microsoft e as melhores ferramentas de desenvolvimento. Os clientes do Office 365 obterão aplicativos inovadores ou específicos do setor que aumentam a produtividade e mantêm todo o controle sobre os dados. Para obter mais informações, confira [Visão geral](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki)

## Sumário
1. [Executar pipelines do ADF para copiar dados do Office 365](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data)
    * [Pré-requisitos](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#prerequisites)
    * [Propriedades do serviço vinculado](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#linked-service-properties)
    * [Propriedades do conjunto de dados](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#dataset-properties)
    * [Exemplos](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#samples)
2. [Publicar um aplicativo gerenciado do Azure para copiar os dados do Office 365](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data)
    * [Criar um aplicativo gerenciado](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-2-create-a-managed-application)
    * [Publicar um aplicativo gerenciado](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-3-publish-a-managed-application)
3. [Recursos](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities)
    * [Coletores do ADF](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#adf-sinks)
    * [Políticas de conformidade](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#policies)
    * [Áreas de dados](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#data-regions)
    * [Conjuntos de dados](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#datasets)
    * [Filtros](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#filters)
    * [Seleção de usuário](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#user-selection)
## Links rápidos
* [Aprovar uma solicitação de acesso a dados](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Approving-a-data-access-request)
* [Gerenciar pipelines do ADF](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Azure-Data-Factory-Quick-Links)

## Ajuda
* [PERGUNTAS FREQUENTES](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/FAQ)  
* [Solução de problemas](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting)
    * [Tratamento de erros](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting#errors)
* [Fale conosco](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Contact-Us)


## Colaboração

Este projeto recebe e agradece as contribuições e sugestões.
A maioria das contribuições exige que você concorde com um CLA (Contrato de Licença de Contribuinte) declarando que você tem o direito
e realmente nos concede os direitos de usar sua contribuição. Para saber mais, acesse https://cla.microsoft.com.

Quando você envia uma solicitação de pull, um bot de CLA determina automaticamente se você precisa fornecer um CLA
e decora o PR adequadamente (por exemplo, rótulo, comentário). Basta seguir as instruções fornecidas pelo bot.
Você só precisa fazer isso uma vez em todos os repositórios que usam nosso CLA.

Este projeto adotou o [Código de Conduta de Código Aberto da Microsoft](https://opensource.microsoft.com/codeofconduct/).
Para saber mais, confira as [Perguntas frequentes sobre o Código de Conduta](https://opensource.microsoft.com/codeofconduct/faq/)
ou entre em contato pelo [opencode@microsoft.com](mailto:opencode@microsoft.com) se tiver outras dúvidas ou comentários.
