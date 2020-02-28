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
# Microsoft Graph データ接続
#### Azure 分析サービスを使用して、Office 365 データを使用してインテリジェントなアプリケーションを構築する 

## 概要 

Microsoft Graph データ接続では、Office 365 データおよび Azure リソースを独立系ソフトウェア ベンダー (ISV)に提供します。このシステムを使用することにより、ISV は Microsoft の最も重要なデータと優れた開発ツールを使用してインテリジェントなアプリケーションを構築できます。Office 365 のお客様には、自身のデータに対する完全なコントロールを維持しつつ生産性を向上させることを可能にする、革新的な業界専用のアプリケーションが提供されます。詳細については、「[概要](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki)」を参照してください。

## 目次
1. [ADF パイプラインを実行して Office 365 データをコピーする](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data)
    * [前提条件](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#prerequisites)
    * [リンクされたサービスのプロパティ](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#linked-service-properties)
    * [データ セットのプロパティ](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#dataset-properties)
    * [サンプル](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Run-Azure-Data-Factory-pipelines-to-copy-Office-365-Data#samples)
2. [Azure 管理アプリケーションを発行して Office 365 データをコピーする](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data)
    * [管理アプリケーションを作成する](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-2-create-a-managed-application)
    * [管理アプリケーションを発行する](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Publish-an-Azure-Managed-Application-to-copy-Office-365-data#step-3-publish-a-managed-application)
3. [機能](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities)
    * [ADF シンク](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#adf-sinks)
    * [コンプライアンス ポリシー](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#policies)
    * [データの地域](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#data-regions)
    * [データセット](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#datasets)
    * [フィルター](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#filters)
    * [ユーザーの選択](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Capabilities#user-selection)
## クイック リンク
* [データ アクセス要求を承認する](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Approving-a-data-access-request)
* [ADF パイプラインを管理する](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Azure-Data-Factory-Quick-Links)

## ヘルプ
* [FAQ](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/FAQ)  
* [トラブルシューティング](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting)
    * [エラー処理](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Troubleshooting#errors)
* [お問い合わせください](https://github.com/OfficeDev/MS-Graph-Data-Connect/wiki/Contact-Us)


## 投稿

このプロジェクトは投稿や提案を歓迎します。たいていの投稿には、投稿者のライセンス契約 (CLA)
に同意することにより、投稿内容を使用する権利を Microsoft に付与する権利が自分にあり、
実際に付与する旨を宣言していただく必要があります。詳細については、https://cla.microsoft.com をご覧ください。

プル要求を送信すると、CLA を提供して PR を適切に修飾する (ラベル、コメントなど) 必要があるかどうかを CLA
ボットが自動的に判断します。ボットの指示に従ってください。この操作は、CLA
を使用してすべてのリポジトリ全体に対して 1 度のみ行う必要があります。

このプロジェクトでは、[Microsoft Open Source Code of Conduct (Microsoft オープン ソース倫理規定)](https://opensource.microsoft.com/codeofconduct/)
が採用されています。詳細については、「[Code of Conduct の FAQ (倫理規定の FAQ)](https://opensource.microsoft.com/codeofconduct/faq/)」を参照してください。
また、その他の質問やコメントがあれば、[opencode@microsoft.com](mailto:opencode@microsoft.com) までお問い合わせください。
