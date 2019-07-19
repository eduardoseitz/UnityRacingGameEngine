using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.InputSystem
{
    /* Input object class */
    // Should be used as a parameter type
    [System.Serializable]
    public class ControllerInput
    {
        public string buttonName;
        public string axisName;
        [Range(0, 0.9f)] public float axisDeadzone = 0.1f;
        public bool isAxisInverted;
    }
}
