using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem 
{
    /* Wheel object class */
    // Should be used as a parameter type
    [System.Serializable]
    class Wheel
    {
        [Tooltip("Wheel's center position.")]
        public Transform centerTransform;

        [Tooltip("Prefab with wheel model.")]
        public GameObject wheelModel;
    }
}
