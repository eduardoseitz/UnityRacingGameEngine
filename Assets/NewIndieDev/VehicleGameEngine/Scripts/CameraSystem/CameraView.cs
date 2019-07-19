using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.CameraSystem
{
    [System.Serializable]
    class CameraView
    {
        public string viewName;
        [Tooltip("The object that this camera is supposed to follow")]
        public Transform targetTransform;
        [Tooltip("How many seconds before following the target.")]
        public float followDelay;
        [Tooltip("How many seconds before following the target turning.")]
        public float turnDelay;
        [Tooltip("")]
        [Range(20f, 100f)] public float minFieldOfView = 55f;
        [Tooltip("")]
        [Range(20f, 100f)] public float maxFieldOfView = 65f;
    }
}
