using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem
{
    //
    public class BrakeBehaviour : MonoBehaviour
    {
        #region Declarations
        [Header("Vehicle Brakes")]
        [Space(2f)]

        [Header("Brakes Setup")]
        [Tooltip("How fast does this vehicle's brakes in Km/h.")]
        [SerializeField] float brakeForce = 25f;
        [Tooltip("How fast does this vehicle's brakes in Km/h.")]
        [SerializeField] float handrakeForce = 50f;

        [Header("Wheels Setup")]
        [SerializeField] WheelCollider[] frontWheels;
        [SerializeField] WheelCollider[] rearWheels;

        // Local variables
        float _currentBrakeForce;
        float _currentHandbrakeForce;
        #endregion

        #region Helper Methods
        // Apply brake force to the vehicle
        public void BrakeVehicle(float brakeInput)
        {
            // Calculate and store brake force to be applied
            _currentBrakeForce = brakeForce * brakeInput;

            // Apply brake force to the front wheels
            for (int wheel = 0; wheel < frontWheels.Length; wheel++)
            {
                frontWheels[wheel].brakeTorque = _currentBrakeForce;
            }

            // Apply brake force to the rear wheels
            for (int wheel = 0; wheel < rearWheels.Length; wheel++)
            {
                rearWheels[wheel].brakeTorque = _currentBrakeForce * 0.5f;
            }
        }

        // Apply handbrake force to the vehicle
        public void handbrakeVehicle(float handbrakeInput)
        {
            // Calculate and store handbrake force to be applied
            _currentHandbrakeForce = handrakeForce * handbrakeInput;

            // Apply handbrake force to the rear wheels
            for (int wheel = 0; wheel < rearWheels.Length; wheel++)
            {
                rearWheels[wheel].brakeTorque = _currentHandbrakeForce;
            }
        }
        #endregion
    }
}
