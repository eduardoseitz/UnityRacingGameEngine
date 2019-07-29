using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem
{
    public class TuningController : MonoBehaviour
    {
        #region Declarations
        [Header("Front Wheels Setup")]
        [SerializeField] Wheel[] leftFrontWheels;
        [SerializeField] Wheel[] rightFrontWheels;
        [Header("Rear Wheels Setup")]
        [SerializeField] Wheel[] leftRearWheels;
        [SerializeField] Wheel[] rightRearWheels;

        // Object Classes
        [System.Serializable]
        public class Wheel
        {
            public Rim rim;
            public Transform transform;
        }
        #endregion
        
        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            // Setup left front wheels
            for (int currentWheel = 0; currentWheel < leftFrontWheels.Length; currentWheel++)
            {
                SwapWheel(leftFrontWheels[currentWheel]);
            }

            // Setup right front wheels
            for (int currentWheel = 0; currentWheel < rightFrontWheels.Length; currentWheel++)
            {
                SwapWheel(rightFrontWheels[currentWheel]);
            }
            
            // Setup left rear wheels
            for (int currentWheel = 0; currentWheel < leftRearWheels.Length; currentWheel++)
            {
                SwapWheel(leftRearWheels[currentWheel]);
            }

            // Setup right rear wheels
            for (int currentWheel = 0; currentWheel < rightRearWheels.Length; currentWheel++)
            {
                SwapWheel(rightRearWheels[currentWheel]);
            }
        }
        #endregion

        #region Helper Methods
        void SwapWheel(Wheel wheel)
        {
            /* TO DO Store the new wheel in a object so it can be easily accessed later and optimizated */
            GameObject _newRim = Instantiate(wheel.rim.model, wheel.transform.position, wheel.transform.rotation);
            _newRim.GetComponent<Transform>().SetParent(wheel.transform);
        }
        #endregion
    }
}
