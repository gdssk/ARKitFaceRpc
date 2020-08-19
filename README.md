# ARKitFaceRpc
人によって顔の作りが違うため、同じ表情をしていても顔認識の結果は微妙に異なります。

例えばFaceTrackingのデータをキャラクターに反映したいと思った場合、綺麗に動かすためにはその結果に何らかの補正をかけてあげる必要があります。

その度にiOSアプリを更新していくのは大変なので、結果だけを送信するアプリを作ってみました。

# Environment
- Unity2019.4.7f1 or abobe
- Mirror v16.11.2
- ARFoundation 4.0.2
- ARKitFaceTracking 4.0.2

# How to use
1. プロジェクトにMirror(https://github.com/vis2k/Mirror/releases/tag/v16.11.2)を追加してください。
2. `ARFaceRPC/Scenes/Client` を起動のシーンになるようにしてiOSアプリとしてビルドし、端末にインストールしてください。

3. `ARFaceRPC/Scenes/Server` をエディタで起動して、HUDの「ServerOnly」をクリックしてください。
4. インストールしたiOSアプリを起動して、HUDで送信先デバイスのIPアドレスを入力した後、「Client」をクリックしてください。

![HUD](https://github.com/gdssk/ARKitFaceRpc/blob/master/Document/HUD.png)

5. エディタのFaceReceiverコンポーネントにデータが流れてきていたら成功です。

![FaceReceiver](https://github.com/gdssk/ARKitFaceRpc/blob/master/Document/FaceReceiver.gif)
