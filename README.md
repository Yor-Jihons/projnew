# projnew

## はじめに

このCLIツールは、GitHub上で管理しているプロジェクトをボイラーテンプレートのようにcloneして開発しやすくするためのツールです。

## コンセプト

私は今まで、GitHubで管理していたボイラーテンプレートプロジェクトを手動でcloneして、既存の`.git`ディレクトリを削除して、プロジェクト名を変えて…とやっていました。これを`projnew new electron 新規プロジェクト名`のようにするだけでぽいらーテンプレートが自動的に作成されて開発しやすくなります。

## 概要

GitHub上で管理しているボイラーテンプレートをcloneして、新規プロジェクト用に書き換える。

## 技術選定理由

エコシステムが豊富で、かつマルチプラットフォームなCLIツール開発に向いているためです。

## デモ動画

// TODO: ここに配置

## 環境

* Windows 11以降(または.NET8が入っているOS)

## 利用方法

### Step1. 初期設定

#### Step1.1. GitHub上で対象のボイラーテンプレートプロジェクトを管理する

#### Step1.2. projnew用の初期設定

```shell
projnew init
```

#### Step1.3. `$HOME/.projnew/projnew.templates.json`の書き換え

Step1.1で管理しているボイラーテンプレートをcloneするように書き換える。

### Step2. projnewの呼び出し

```shell
projnew new electron 新規プロジェクト名
```

## コマンド

### projnewの初期設定

```shell
projnew init
```

### projnewで使えるテンプレートの名前の列挙

```shell
projnew list
```

### projnewで新規プロジェクトの作成

```shlell
projnew new テンプレート名 新規プロジェクト名
```

## 制約

* `$HOME/.projnew/projnew.templates.json`に記述されているテンプレートしか使えないとする
* .NET8必須
* 現時点では`git`コマンドのインストールが必須
* 現時点ではWindowsのみ対応

## 実装予定の機能

* WindowsかUnix系かでコマンドを分岐させること(現時点ではWindowsのみ対応)

## プロジェクトの構成

テストは`projnew/main.xUnits`ディレクトリ内にあり、本番プロジェクトは`projnew/main`ディレクトリ内にあります。

