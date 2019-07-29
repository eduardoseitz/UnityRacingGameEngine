using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem
{
    /* Engine object class */
    [CreateAssetMenu(fileName = "NewRim", menuName = "New Indie Dev/Vehicle Game Engine/Parts/Suspension/Rim")]
    public class Rim : ScriptableObject
    {
        [Tooltip("Model prefab.")]
        public GameObject model;
    }
}
