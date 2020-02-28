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
# Connexion aux données Microsoft Graph
#### Utilisation de données Office 365 avec Azure Analytics pour créer des applications intelligentes 

## Introduction 

La connexion aux données Microsoft Graph transmet des données Office 365 et des ressources Azure aux éditeurs de logiciels indépendants (ISV). Ce système permet aux éditeurs de logiciels indépendants de créer des applications intelligentes à l'aide des données les plus importantes de Microsoft et des meilleurs outils de développement. Les clients Office 365 peuvent ainsi profiter d’applications innovantes ou propres à leur secteur, permettant d’améliorer leur productivité tout en gardant un contrôle total sur leurs données. Pour plus d'informations, voir la [Vue d’ensemble](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki)

## Table des matières
1. [Exécuter les pipelines Azure Data Factory (ADF) pour copier des données Office 365](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data)
    * [Conditions préalables](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#prerequisites)
    * [Propriétés de service liées](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#linked-service-properties)
    * [Propriétés du groupe de données](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#dataset-properties)
    * [Exemples](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#samples)
2. [Publier une application gérée Azure pour copier les données Office 365](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data)
    * [Créer une application gérée](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-2-create-a-managed-application)
    * [Publier une application gérée](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-3-publish-a-managed-application)
3. [Fonctionnalités](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities)
    * [Récepteurs Azure Data Factory](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#adf-sinks)
    * [Stratégies de conformité](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#policies)
    * [Régions de données](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#data-regions)
    * [Jeux de données](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#datasets)
    * [Filtres](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#filters)
    * [Sélection de l'utilisateur](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#user-selection)
## Liens rapides
* [Approuver une demande d’accès aux données](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Approving-a-data-access-request)
* [Gérer les pipelines Azure Data Factory](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Azure-Data-Factory-Quick-Links)

## Aide
* [FAQ](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/FAQ)  
* [Résolution des problèmes](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting)
    * [Gestion des erreurs](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting#errors)
* [Contactez-nous](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Contact-Us)


## Contribution

Ce projet autorise les contributions et les suggestions. Pour la plupart des contributions, vous devez accepter le Contrat de licence de contributeur (CLA)
stipulant que vous êtes en mesure, et que vous vous y engagez, de nous accorder les droits d’utiliser votre contribution.
Pour plus d’informations, visitez https://cla.microsoft.com.

Lorsque vous soumettez une demande de tirage, un robot CLA détermine automatiquement si vous devez fournir un Contrat de licence de contributeur et si vous devez remplir
la demande de tirage appropriée (par ex., étiquette, commentaire).
Suivez simplement les instructions données par le robot. Vous ne devez le faire qu’une seule fois pour l'ensemble des référentiels utilisant le Contrat de licence de contributeur.

Ce projet a adopté le [Code de conduite Open Source de Microsoft](https://opensource.microsoft.com/codeofconduct/).
Pour en savoir plus, reportez-vous à la [FAQ relative au code de conduite](https://opensource.microsoft.com/codeofconduct/faq/)
ou contactez [opencode@microsoft.com](mailto:opencode@microsoft.com) pour toute question ou tout commentaire.
