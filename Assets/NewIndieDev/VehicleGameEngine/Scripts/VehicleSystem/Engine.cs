using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem
{
    /* Engine object class */
    [CreateAssetMenu(fileName = "NewEngine", menuName = "New Indie Dev/Vehicle Game Engine/Parts/Drivetrain/Engine")]
    public class Engine : ScriptableObject
    {
        [Tooltip("Maximum engine power output in Kw.")]
        public float maxPower = 164f;
        [Tooltip("Maximum engine torque delivered in N/m")]
        public float maxTorque = 285f;
    }
}
