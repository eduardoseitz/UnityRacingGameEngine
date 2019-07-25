using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem
{
    public class SuspensionBehaviour : MonoBehaviour
    {
        #region Declarations
        [Header("Vehicle Suspension")]
        [Space(2f)]

        [Header("Steering Setup")]
        [SerializeField] float steerAngleStep = 0.1f;
        [SerializeField] float maxSteerAngle = 40f;

        [Header("Steering Wheels Setup")]
        [SerializeField] WheelCollider[] axleWheels;

        // Script references
        PowertrainBehaviour powertrain;

        // Local variables
        float _currentSteerAngle;
        #endregion

        #region Main Methods
        private void Awake()
        {
            powertrain = GetComponent<PowertrainBehaviour>();
        }
        #endregion

        #region Helper Methods
        // Turn vehicle based on steering input
        public void TurnAxleWheels(float steeringInput)
        {
            // When steering and moving
            if (steeringInput != 0)
            {
                _currentSteerAngle += steerAngleStep * steeringInput;
                if (_currentSteerAngle > maxSteerAngle)
                    _currentSteerAngle = maxSteerAngle;
                if (_currentSteerAngle < -maxSteerAngle)
                    _currentSteerAngle = -maxSteerAngle;       
            }
            // When not steering at all
            else
            {
                _currentSteerAngle = 0;
            }

            // Finnaly pass steer angle to the axle wheels
            for (int axis = 0; axis < axleWheels.Length; axis++)
            {
                axleWheels[axis].steerAngle = _currentSteerAngle;
            }
        }
        #endregion
    }
}
