using UnityEngine;
using NewIndieDev.VehicleGameEngine.UISystem;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem
{
    public class PowertrainBehaviour : MonoBehaviour
    {
        #region Declarations
        [Header("Vehicle Powertrain")]

        [Header("Engine Setup")]
        [SerializeField] Engine engine;

        [Header("Wheels Setup")]
        [SerializeField] WheelCollider[] poweredWheels;
        
        public float currentSpeed;
        float _currentTorque;

        // Physics conversion constants
        const float _kilometersTometerBySeconds = 0.2778f;
        #endregion

        #region Main Methods
        private void Update()
        {
            // Pass speed to the ui manager /* NOT WORKING */
            /*if (UIManager.instance)
                UIManager.instance.UpdateSpeedometer(currentSpeed);*/
        }
        #endregion

        #region Helper Methods
        // Updates the vehicle engine.currentTorque prarameter
        public void ApplyTorqueToWheels(float throttleInput)
        {
            _currentTorque = throttleInput * engine.maxTorque;

            // Increases or decreases vehicle acceleration force
            for (int collider = 0; collider < poweredWheels.Length; collider++)
            {
                poweredWheels[collider].motorTorque = _currentTorque;
            }

            // Stores current speed to be used by UI
            currentSpeed += _currentTorque / 0.5f /* Wheel diameter*/ * Time.deltaTime;
        }
        #endregion
    }
}
