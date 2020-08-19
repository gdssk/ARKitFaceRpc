using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace ARFaceRpc
{
    public class FaceReceiver : MonoBehaviour
    {
        [SerializeField]
        private FaceData data;

        public static Action<FaceData> OnDataReceived;

        void Start()
        {
            Mirror.NetworkServer.RegisterHandler<FaceData>(OnReceived);
        }

        private void OnDestroy()
        {
            Mirror.NetworkServer.UnregisterHandler<FaceData>();
        }

        /// <summary>
        /// 受信
        /// </summary>
        /// <param name="nc"></param>
        /// <param name="data"></param>
        void OnReceived(NetworkConnection nc, FaceData data)
        {
            this.data = data;
            OnDataReceived?.Invoke(data);
        }
    }
}
