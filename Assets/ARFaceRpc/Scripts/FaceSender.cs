using System;
using System.Collections.Generic;
using Mirror;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;
using UnityEngine.XR.ARSubsystems;
#if UNITY_IOS && !UNITY_EDITOR
using UnityEngine.XR.ARKit;
#endif

namespace ARFaceRpc
{
    [RequireComponent(typeof(ARFace))]
    public class FaceSender : MonoBehaviour
    {
    #if UNITY_IOS && !UNITY_EDITOR
        ARKitFaceSubsystem m_ARKitFaceSubsystem;
    #endif

        ARFace m_Face;

        void Awake()
        {
            m_Face = GetComponent<ARFace>();
        }

        void OnEnable()
        {
    #if UNITY_IOS && !UNITY_EDITOR
            var faceManager = FindObjectOfType<ARFaceManager>();
            if (faceManager != null)
            {
                m_ARKitFaceSubsystem = (ARKitFaceSubsystem)faceManager.subsystem;
            }
    #endif
            m_Face.updated += OnUpdated;
            ARSession.stateChanged += OnSystemStateChanged;
        }

        void OnDisable()
        {
            m_Face.updated -= OnUpdated;
            ARSession.stateChanged -= OnSystemStateChanged;
        }

        void OnSystemStateChanged(ARSessionStateChangedEventArgs eventArgs)
        {
            if (!Mirror.NetworkClient.isConnected)
            {
                return;
            }
            var data = new FaceData();
            data.ARSessionStatus = (int)eventArgs.state;
            Mirror.NetworkClient.Send(data);
        }

        void OnUpdated(ARFaceUpdatedEventArgs eventArgs)
        {
            UpdateFaceFeatures();
        }

        void UpdateFaceFeatures()
        {
            if (!Mirror.NetworkClient.isConnected)
            {
                return;
            }
    #if UNITY_IOS && !UNITY_EDITOR
            using (var blendShapes = m_ARKitFaceSubsystem.GetBlendShapeCoefficients(m_Face.trackableId, Allocator.Temp))
            {
                var data = new FaceData();
                data.FaceAngle = m_Face.transform.localEulerAngles;
                data.TrackingStatus = (int)m_Face.trackingState;

                data.leftEyePosition = m_Face.leftEye.position;
                data.leftEyeAngle = m_Face.leftEye.localEulerAngles;

                data.rightEyePosition = m_Face.rightEye.position;
                data.rightEyeAngle = m_Face.rightEye.localEulerAngles;

                foreach (var featureCoefficient in blendShapes)
                {
                    switch (featureCoefficient.blendShapeLocation)
                    {
                        case ARKitBlendShapeLocation.BrowDownLeft:
                            data.BrowDownLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.BrowDownRight:
                            data.BrowDownRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.BrowInnerUp:
                            data.BrowInnerUp = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.BrowOuterUpLeft:
                            data.BrowOuterUpLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.BrowOuterUpRight:
                            data.BrowOuterUpRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.CheekPuff:
                            data.CheekPuff = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.CheekSquintLeft:
                            data.CheekSquintLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.CheekSquintRight:
                            data.CheekSquintRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeBlinkLeft:
                            data.EyeBlinkLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeBlinkRight:
                            data.EyeBlinkRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeLookDownLeft:
                            data.EyeLookDownLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeLookDownRight:
                            data.EyeLookDownRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeLookInLeft:
                            data.EyeLookInLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeLookInRight:
                            data.EyeLookInRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeLookOutLeft:
                            data.EyeLookOutLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeLookOutRight:
                            data.EyeLookOutRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeLookUpLeft:
                            data.EyeLookUpLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeLookUpRight:
                            data.EyeLookUpRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeSquintLeft:
                            data.EyeSquintLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeSquintRight:
                            data.EyeSquintRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeWideLeft:
                            data.EyeWideLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.EyeWideRight:
                            data.EyeWideRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.JawForward:
                            data.JawForward = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.JawLeft:
                            data.JawLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.JawOpen:
                            data.JawOpen = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.JawRight:
                            data.JawRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthClose:
                            data.MouthClose = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthDimpleLeft:
                            data.MouthDimpleLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthDimpleRight:
                            data.MouthDimpleRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthFrownLeft:
                            data.MouthFrownLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthFrownRight:
                            data.MouthFrownRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthFunnel:
                            data.MouthFunnel = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthLeft:
                            data.MouthLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthLowerDownLeft:
                            data.MouthLowerDownLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthLowerDownRight:
                            data.MouthLowerDownRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthPressLeft:
                            data.MouthPressLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthPressRight:
                            data.MouthPressRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthPucker:
                            data.MouthPucker = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthRight:
                            data.MouthRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthRollLower:
                            data.MouthRollLower = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthRollUpper:
                            data.MouthRollUpper = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthShrugLower:
                            data.MouthShrugLower = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthShrugUpper:
                            data.MouthShrugUpper = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthSmileLeft:
                            data.MouthSmileLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthSmileRight:
                            data.MouthSmileRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthStretchLeft:
                            data.MouthStretchLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthStretchRight:
                            data.MouthStretchRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthUpperUpLeft:
                            data.MouthUpperUpLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.MouthUpperUpRight:
                            data.MouthUpperUpRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.NoseSneerLeft:
                            data.NoseSneerLeft = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.NoseSneerRight:
                            data.NoseSneerRight = featureCoefficient.coefficient;
                            break;
                        case ARKitBlendShapeLocation.TongueOut:
                            data.TongueOut = featureCoefficient.coefficient;
                            break;
                    }
                }
                Mirror.NetworkClient.Send(data);
            }
    #endif
        }
    }
}
