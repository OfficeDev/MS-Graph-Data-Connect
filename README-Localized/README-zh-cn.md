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
# Microsoft Graph 数据连接
#### 使用 Office 365 数据和 Azure 分析来构建智能应用程序 

## 简介 

Microsoft Graph 数据连接可为独立软件供应商 (ISV) 提供 Office 365 数据和 Azure 资源。通过此系统，ISV 可使用 Microsoft 最有价值的数据和最出色的开发工具来构建智能应用程序。Office 365 客户将获得创新的或行业特定的应用程序，以便提高工作效率，同时保持对其数据的完全控制。有关详细信息，请参阅[概述](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki)

## 目录
1. [运行 ADF 管道以复制 Office 365 数据](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data)
    * [先决条件](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#prerequisites)
    * [关联的服务属性](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#linked-service-properties)
    * [数据集属性](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#dataset-properties)
    * [示例](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#samples)
2. [发布 Azure 托管应用程序以复制 Office 365 数据](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data)
    * [创建托管应用程序](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-2-create-a-managed-application)
    * [发布托管应用程序](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-3-publish-a-managed-application)
3. [功能](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities)
    * [ADF 接收器](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#adf-sinks)
    * [符合性策略](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#policies)
    * [数据区域](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#data-regions)
    * [数据集](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#datasets)
    * [筛选器](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#filters)
    * [用户选择](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#user-selection)
## 快速链接
* [批准数据访问请求](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Approving-a-data-access-request)
* [管理 ADF 管道](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Azure-Data-Factory-Quick-Links)

## 帮助
* [常见问题解答](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/FAQ)  
* [疑难解答](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting)
    * [错误处理](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting#errors)
* [联系我们](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Contact-Us)


## 参与

本项目欢迎供稿和建议。大多数的供稿都要求你同意“参与者许可协议 (CLA)”
声明你有权并确定授予我们使用你所供内容的权利。
有关详细信息，请访问 https://cla.microsoft.com。

在提交拉取请求时，CLA 机器人会自动确定你是否需要提供 CLA
并适当地修饰 PR（例如标记、批注）。只需按照机器人提供的说明操作即可。
只需在所有存储库上使用我们的 CLA 执行此操作一次。

此项目已采用 [Microsoft 开放源代码行为准则](https://opensource.microsoft.com/codeofconduct/)。
有关详细信息，请参阅[行为准则常见问题解答](https://opensource.microsoft.com/codeofconduct/faq/)。
如有其他任何问题或意见，也可联系 [opencode@microsoft.com](mailto:opencode@microsoft.com)。
