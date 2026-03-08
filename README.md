# free_work_cs

C# の学習・検証用に作成したサンプルプロジェクト群です。各ディレクトリでデザインパターン、言語機能、ライブラリの使い方などを個別に実装しています。

## 各ディレクトリで実装していること

- **CommandPattern**  
  コマンドパターンのサンプル。Invoker がコマンドをキューに積み、Receiver に対して加算・減算を実行する。
  https://qiita.com/sebayashi-tomoya/items/d0eb37b9bd849edd436d

---

- **ObserverPattern**  
  オブザーバーパターンのサンプル。メニュー（Subject）の変更を Eater（Observer）が購読し、該当メニューになったら反応する。購読解除も可能。
  https://qiita.com/sebayashi-tomoya/items/b23c3b0d09694a47cb37

---

- **Lambda**  
  ラムダ式の基本。二乗計算・Func を引数に取るメソッド・Where/自前 Select など。コールバック（Action）の例も含む。
  https://qiita.com/sebayashi-tomoya/items/135a54733c6d1472fd6c

---

- **Linq**  
  LINQ の基本。Select / Where / OrderBy / First / Any / All / Count、および ToLookup・OfType・Reverse などの例。
  https://qiita.com/sebayashi-tomoya/items/9f00795f503ac900ef15

---

- **LinqZip**  
  Zip の使い方。2つのシーケンス（キャラとタイトルなど）をインデックス対応で結合。3つ以上の結合や数値リストの要素同士の計算も。
  https://qiita.com/sebayashi-tomoya/items/dcad60cad7f2d7466bed

---

- **JsonSerializer**  
  ポリモーフィックな JSON のシリアライズ。ISignal のリストを Newtonsoft.Json で扱い、カスタム JsonConverter で具象型（Red/Green/Yellow Signal）を復元。
  https://qiita.com/sebayashi-tomoya/items/0e4dbd5b830ed29842fe

---

- **GenericBeginner**  
  ジェネリックの基礎。object で持つ場合と GenericItem で持つ場合の型安全性の違いを確認。
  https://qiita.com/sebayashi-tomoya/items/7d91441d3a215ab4d44d

---

- **ReflectionBeginner**  
  リフレクションの基礎。型からアセンブリ情報・コンストラクタ・メンバー情報を取得して出力。
  https://qiita.com/sebayashi-tomoya/items/acfb5b454460361f5266

---

- **ExtensionMethods**  
  拡張メソッドの例。TimeSpan に IsEarly / IsLate / IsWaste を追加し、起床時刻でメッセージを出し分ける。
  https://qiita.com/sebayashi-tomoya/items/e9c665b4692b40b71f5f

---

- **ExceptionBestPractice**  
  例外の再スロー。ExceptionDispatchInfo.Capture と Throw でスタックトレースを保持したまま再スローする。
  https://qiita.com/sebayashi-tomoya/items/087a52f8b16577002323

---

- **UseLazy**  
  Lazy&lt;T&gt; の遅延初期化。Value に初めてアクセスしたときに重いオブジェクトを生成する例と、キャッシュ的な利用例。
  https://qiita.com/sebayashi-tomoya/items/09d5825b0935ea372c73
  https://qiita.com/sebayashi-tomoya/items/5fbc7abdffe136c253b8

---

- **UseThreadPool**  
  ThreadPool の基本。QueueUserWorkItem で仕事を投入し、別スレッドで実行させる。
  https://qiita.com/sebayashi-tomoya/items/466c164fb2f417c1adbf

---

- **UseNewNullCheck**  
  ヌル条件演算子（?.）の動作確認。null のオブジェクトに対して item?.Name = "hoge" しても例外にならないことを確認。
  https://qiita.com/sebayashi-tomoya/items/94d0af9a748590da2d5f

---

- **UseNewSwitch**  
  新しい switch 式。ジョジョの部番号から主人公・サブタイトルを返す PartInfoWriter と、enum でスタンド名を返す StandBattle。
  https://qiita.com/sebayashi-tomoya/items/8ccbace5051b18060aa7

---

- **ReadonlyOrConst**  
  readonly と const の違い。VersionDefinition でバージョン比較し、VersionChecker でメッセージを表示。
  https://qiita.com/sebayashi-tomoya/items/9daa18668882d2388cd7

---

- **ReactiveCollection**  
  Reactive.Bindings の ReactiveCollection。要素の追加を ObserveAddChanged でサブスクライブしてコンソールに出力。
  https://qiita.com/sebayashi-tomoya/items/1f71e19f6587503f193e

---

- **DictionaryOrLookUp**  
  Dictionary（1キー1値）と Lookup（1キー多値・ToLookup）の違い。ユーザー年齢・部署別メンバー・カテゴリ別商品などの例。
  https://qiita.com/sebayashi-tomoya/items/82c52e26d3b329970a46

---

- **PassValueOrPassReference**  
  ref と out の動作確認。ref で呼び出し元の変数を書き換え、out で複数の返り値（値＋bool）を受け取る例。
  https://qiita.com/sebayashi-tomoya/items/902fe66fcf3ad0dfa20f

---

- **DbConnTest**  
  MySQL への接続とテーブルデータ取得。MySql.Data で非同期に接続し、指定テーブルの SELECT 結果をコンソールに表示。

---

- **Modoreko**  
  Stack を使った逆再生デモ。通常は位置が進み、Enter で過去の位置に巻き戻す。Esc で終了。
  https://qiita.com/sebayashi-tomoya/items/bcc4a512543e5eb39fe4
