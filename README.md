# AviUtlExoToAup2Converter
旧AviUtl拡張編集のエクスポートファイル（exo）を、AviUtl2のプロジェクトファイル（aup2）に変換するツールです。

大体最近のWindows11なら動くと思います。

## 変換機能
変換対象のExoファイルと変換ロジック定義XMLを入力し、Aup2形式に変換する機能。
<img width="786" height="443" alt="image" src="https://github.com/user-attachments/assets/7ac3cfa2-c48d-403b-930e-e0725fb518bf" />

## 設定機能
変換ロジック定義XMLを編集するためのビジュアルスクリプティングツール。
<img width="993" height="741" alt="image" src="https://github.com/user-attachments/assets/0252025f-a98c-404e-8d00-c3676aa73a61" />


# 使い方
## 変換機能
1. Exoファイルを出力
2. アプリケーションを起動
3. Exoファイルのパスを左上のテキストボックスに入力
4. テキストボックス右の読み込みボタンを押下
5. 変換ロジック定義XMLファイルのパスを左上二段目のテキストボックスに入力
6. テキストボックス右の読み込みボタンを押下
7. 中央の変換ボタンを押下
8. 出力先パスを確認し、右上の保存を押下

## 設定機能
変換ロジックは任意の数の「ロジックアイテム」で構成される。

変換ロジックコアは変換元のExoファイルの「フィルタ」毎に全ロジックアイテムを検索し、「条件」に合致するロジックアイテムが実行される。

- 既存のファイルを読み込む場合... 変換ロジック定義XMLファイルのパスを上のテキストボックスに入力
- 新規に作成する場合... 右側のロジックを新規作成ボタンを押下

### 条件
「条件」には左側ペインの条件タブにあるノードが設定できる。

<img width="377" height="68" alt="image" src="https://github.com/user-attachments/assets/ee97aed0-8339-48a3-989a-90aeff8c8e1b" />

「値」1と「値」2が一致しているときに真になるノード。

<img width="161" height="154" alt="image" src="https://github.com/user-attachments/assets/95ef308e-025e-4785-866b-4c8ae751855f" />

「条件」1と「条件」2が一致しているときに真になるノード。

なお基本的に想定している「条件」は、”「フィルタ」の名前が特定の文字列と一致する”というもの。

### エフェクト名
変換前の「フィルタ」は、変換後に「エフェクト」となる。そのエフェクトの名称。

**この名称がAviUtl2で定義されているエフェクト名と完全に一致していないと、正常なエフェクトとして認識されない。**

### 変数
再利用される複雑な「値」に名前をつけて参照することができる。上級者向け。

任意の数定義できる。

### マッピング
変換前の「フィルタ」に定義されている各「属性」が、変換後の「エフェクト」のどの「属性」と対応するかを定義する。

任意の数定義できる。

「マッピング」には左側ペインのマッピングタブにあるノードが設定できる。

<img width="316" height="48" alt="image" src="https://github.com/user-attachments/assets/3a209eb6-3743-4fa6-8de9-12470a057b52" />

左側のテキストボックスに入力した名前の「属性」に整数値を設定する。

<img width="449" height="54" alt="image" src="https://github.com/user-attachments/assets/9a0df81c-a292-4d94-9d1e-914c1f0d5902" />

左側のテキストボックスに入力した名前の「属性」に小数値を設定する。

右側のテキストボックスに「桁数」を入力する必要がある。

**エフェクトの名前、属性の構成、すべての属性の桁数がAviUtl2で定義されているものと完全に一致しないと、正常なエフェクトとして認識されない。**

「桁数」には、例えば”0.00”のような二桁を設定したい場合、”F2”、三桁を設定したい場合、”F3”と入力する。

<img width="317" height="50" alt="image" src="https://github.com/user-attachments/assets/c22f2954-af7b-4377-a397-8c0af9c4ced1" />

左側のテキストボックスに入力した名前の「属性」に文字列を設定する。

<img width="518" height="83" alt="image" src="https://github.com/user-attachments/assets/45562c7e-607f-4215-a3b9-6fbc66642c07" />

"再生位置"属性専用のノード。

### 値
「値」は型ごとに色が異なる。

基本的に型が正しい（色が同じ）ノードしか設定できない。

灰色のノードは型が未定のノード。

どこかに色付きのノードを設定し、型が確定するとその色に変わる。

<img width="331" height="59" alt="image" src="https://github.com/user-attachments/assets/e24c0c03-4d66-4773-8df8-7559e49b0fec" />

一つの整数値を設定する。

<img width="325" height="60" alt="image" src="https://github.com/user-attachments/assets/3ae4abff-780c-4284-a261-add4d65eb57e" />

一つの小数値を設定する。

<img width="325" height="61" alt="image" src="https://github.com/user-attachments/assets/87c5ae81-2861-4675-af68-f88d574b6309" />

一つの文字列を設定する。

<img width="274" height="38" alt="image" src="https://github.com/user-attachments/assets/40b37b75-ad89-4364-a9f8-7a307b819ca2" />

「変数」から指定した名前の「属性」を取得する。

<img width="208" height="41" alt="image" src="https://github.com/user-attachments/assets/03534d97-1f24-4b83-b238-d4eff40d19ce" />

「変数」オブジェクトそのものに定義されたプロパティを取得する。（説明が難しい）

<img width="199" height="59" alt="image" src="https://github.com/user-attachments/assets/27952b44-afca-4c80-8e11-b3d4e30aa2ce" />

変換元のExoファイルのすべての「フィルタ」から、指定した名前に合致する最初の「フィルタ」を取得する。上級者向け。

### 計算・変換

<img width="279" height="69" alt="image" src="https://github.com/user-attachments/assets/11a94b59-8bc8-4bac-a231-45ea9b74be2c" />

2つの「値」の加算。

<img width="282" height="71" alt="image" src="https://github.com/user-attachments/assets/c87e6c6d-900c-4096-b9a5-20765fe738dc" />

2つの「値」の減算。

<img width="142" height="95" alt="image" src="https://github.com/user-attachments/assets/0d2cfa5b-5043-4813-9b98-c19782a25ad3" />

「フィルタ」では整数値として扱われている"合成モード"を、「エフェクト」用の文字列に変換する。

<img width="142" height="96" alt="image" src="https://github.com/user-attachments/assets/9b16f3b8-d594-4356-bc54-8d5d4026a609" />

フレームを時間に変換する。

「フィルタ」では"再生位置"などがフレーム単位で記録されているが、「エフェクト」では時間単位で記録される。

# プロジェクトについて
WPFアプリケーションです。VisualStudio2022Communityで作成しています。
開発にあたっては、VSインストール時にワークロードで「.NET デスクトップ開発」のチェックを入れてください。
WPFアプリケーションの開発に必要なコンポーネントがインストールされます。

MVVMデザインパターンに準じています。
MVVMフレームワークはLivetです。
