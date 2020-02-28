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
# Conexión de datos de Microsoft Graph
#### Usar los datos de Office 365 con Azure Analytics para crear aplicaciones inteligentes 

## Introducción 

La conexión de datos de Microsoft Graph brinda datos de Office 365 y recursos de Azure a los proveedores de software independientes (ISVs). Este sistema permite a los ISV crear aplicaciones inteligentes con los datos más importantes de Microsoft y las mejores herramientas de desarrollo. Los clientes de Office 365 obtendrán aplicaciones innovadoras o específicas del sector que aumentan la productividad mientras ayudan a mantener pleno control sobre los datos. Para obtener más información, consulte [Introducción](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki)

## Tabla de contenido
1. [Ejecutar canalizaciones ADF para copiar datos de Office 365](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data)
    * [Requisitos previos](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#prerequisites)
    * [Propiedades de servicio vinculado](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#linked-service-properties)
    * [Propiedades del conjunto de datos](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#dataset-properties)
    * [Ejemplos](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#samples)
2. [Publicar una aplicación administrada por Azure para copiar datos de Office 365](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data)
    * [Crear una aplicación administrada](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-2-create-a-managed-application)
    * [Publicar una aplicación administrada](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-3-publish-a-managed-application)
3. [Capacidades](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities)
    * [Receptores ADF](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#adf-sinks)
    * [Directivas de cumplimiento](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#policies)
    * [Regiones de datos](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#data-regions)
    * [Conjuntos de datos](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#datasets)
    * [Filtros](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#filters)
    * [Selección del usuario](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#user-selection)
## Vínculos rápidos
* [Aprobar una solicitud de acceso a los datos](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Approving-a-data-access-request)
* [Administrar canalizaciones ADF](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Azure-Data-Factory-Quick-Links)

## Ayuda
* [PREGUNTAS FRECUENTES](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/FAQ)  
* [Solución de problemas](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting)
    * [Control de errores](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting#errors)
* [Contacto](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Contact-Us)


## Colaboradores

Este proyecto recibe las contribuciones y las sugerencias. La mayoría de las contribuciones requiere que acepte un Contrato de Licencia de Colaborador (CLA)
donde declara que tiene el derecho, y realmente lo tiene, de otorgarnos los derechos para usar su contribución.
Para obtener más información, visite https://cla.microsoft.com.

Cuando envíe una solicitud de incorporación de cambios, un bot de CLA determinará automáticamente si necesita proporcionar un CLA y agregar el PR correctamente (por ejemplo, etiqueta, comentario).
Siga las instrucciones proporcionadas por el bot.
Solo debe hacerlo una vez en todos los repositorios que usen nuestro CLA.

Este proyecto ha adoptado el [Código de conducta de código abierto de Microsoft](https://opensource.microsoft.com/codeofconduct/).
Para obtener más información, vea [Preguntas frecuentes sobre el código de conducta](https://opensource.microsoft.com/codeofconduct/faq/)
o póngase en contacto con [opencode@microsoft.com](mailto:opencode@microsoft.com) si tiene otras preguntas o comentarios.
