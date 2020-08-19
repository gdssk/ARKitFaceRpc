using System;
using Mirror;
using UnityEngine;

namespace ARFaceRpc
{
    /// <summary>
    /// 顔情報
    /// </summary>
    [Serializable]
    public class FaceData : MessageBase
    {
        /// <summary>
        /// ARKitのセッション状態
        /// </summary>
        public int ARSessionStatus = -1;

        /// <summary>
        /// トラッキング状態
        /// </summary>
        public int TrackingStatus = -1;
        
        /// <summary>
        /// 顔の角度
        /// </summary>
        public Vector3 FaceAngle;

        /// <summary>
        /// 左目の座標
        /// </summary>
        public Vector3 leftEyePosition;
        /// <summary>
        /// 左目の角度
        /// </summary>
        public Vector3 leftEyeAngle;

        /// <summary>
        /// 右目の座標
        /// </summary>
        public Vector3 rightEyePosition;
        /// <summary>
        /// 右目の角度
        /// </summary>
        public Vector3 rightEyeAngle;

        /// <summary>
        /// 表情データ
        /// https://developer.apple.com/documentation/arkit/arfaceanchor/blendshapelocation
        /// </summary>
        public float BrowDownLeft;
        public float BrowDownRight;
        public float BrowInnerUp;
        public float BrowOuterUpLeft;
        public float BrowOuterUpRight;
        public float CheekPuff;
        public float CheekSquintLeft;
        public float CheekSquintRight;
        public float EyeBlinkLeft;
        public float EyeBlinkRight;
        public float EyeLookDownLeft;
        public float EyeLookDownRight;
        public float EyeLookInLeft;
        public float EyeLookInRight;
        public float EyeLookOutLeft;
        public float EyeLookOutRight;
        public float EyeLookUpLeft;
        public float EyeLookUpRight;
        public float EyeSquintLeft;
        public float EyeSquintRight;
        public float EyeWideLeft;
        public float EyeWideRight;
        public float JawForward;
        public float JawLeft;
        public float JawOpen;
        public float JawRight;
        public float MouthClose;
        public float MouthDimpleLeft;
        public float MouthDimpleRight;
        public float MouthFrownLeft;
        public float MouthFrownRight;
        public float MouthFunnel;
        public float MouthLeft;
        public float MouthLowerDownLeft;
        public float MouthLowerDownRight;
        public float MouthPressLeft;
        public float MouthPressRight;
        public float MouthPucker;
        public float MouthRight;
        public float MouthRollLower;
        public float MouthRollUpper;
        public float MouthShrugLower;
        public float MouthShrugUpper;
        public float MouthSmileLeft;
        public float MouthSmileRight;
        public float MouthStretchLeft;
        public float MouthStretchRight;
        public float MouthUpperUpLeft;
        public float MouthUpperUpRight;
        public float NoseSneerLeft;
        public float NoseSneerRight;
        public float TongueOut;
    }
}