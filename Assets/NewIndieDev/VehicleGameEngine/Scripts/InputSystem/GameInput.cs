using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.InputSystem
{
    /* Input object class */
    // Should be used as a parameter type
    [System.Serializable]
    public class GameInput
    {
        public string inputName;
        public bool isAxis;
        public bool isAxisInverted;
        [Range(0, 0.9f)] public float axisDeadzone = 0.1f;
    }
}
