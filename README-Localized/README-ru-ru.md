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
# Подключение к данным Microsoft Graph
#### Использование данных Office 365 с аналитикой Azure для создания интеллектуальных приложений 

## Введение 

Подключение к данным Microsoft Graph предоставляет независимым поставщикам программного обеспечения данные Office 365 и ресурсы Azure. Эта система позволяет независимым поставщикам программного обеспечения создавать интеллектуальные приложения с самыми важными данными и лучшими средствами разработки Майкрософт. Клиенты Office 365 получают инновационные или отраслевые приложения, повышающие производительность с обеспечением полного контроля над данными. Дополнительные сведения см. в статье [Обзор](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki).

## Оглавление
1. [Запуск конвейеров ADF для копирования данных Office 365](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data)
    * [Предварительные требования](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#prerequisites)
    * [Свойства связанных служб](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#linked-service-properties)
    * [Свойства наборов данных](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#dataset-properties)
    * [Примеры](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#samples)
2. [Публикация управляемого приложения Azure для копирования данных Office 365](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data)
    * [Создание управляемого приложения](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-2-create-a-managed-application)
    * [Публикация управляемого приложения](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-3-publish-a-managed-application)
3. [Возможности](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities)
    * [Приемники ADF](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#adf-sinks)
    * [Политики соответствия](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#policies)
    * [Области данных](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#data-regions)
    * [Наборы данных](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#datasets)
    * [Фильтры](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#filters)
    * [Выбор пользователей](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#user-selection)
## Быстрые ссылки
* [Утверждение запроса на доступ к данным](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Approving-a-data-access-request)
* [Управление конвейерами ADF](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Azure-Data-Factory-Quick-Links)

## Справка
* [Вопросы и ответы](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/FAQ)  
* [Устранение неполадок](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting)
    * [Обработка ошибок](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting#errors)
* [Свяжитесь с нами](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Contact-Us)


## Участие

Мы всегда рады предложениям и помощи в работе над проектом.
Обычно для добавления своих вариантов необходимо принять Лицензионное соглашение с участником (CLA), заявив, что вы имеете право предоставлять и предоставляете нам права на использование своего варианта.
Подробности см. на сайте https://cla.microsoft.com.

Когда вы будете отправлять запрос на вытягивание, CLA-бот автоматически определит, нужно ли вам предоставить CLA
и соответствующим образом изменит внешний вид запроса на вытягивание (например, добавит метку, комментарий).
Просто следуйте инструкциям бота. Это нужно будет сделать всего один раз для добавления своих вариантов во все репозитории, использующие наш CLA.

Этот проект соответствует [Правилам поведения разработчиков открытого кода Майкрософт](https://opensource.microsoft.com/codeofconduct/).
Дополнительные сведения см. в разделе [часто задаваемых вопросов о правилах поведения](https://opensource.microsoft.com/codeofconduct/faq/).
Если у вас возникли вопросы или замечания, напишите нам по адресу [opencode@microsoft.com](mailto:opencode@microsoft.com).
