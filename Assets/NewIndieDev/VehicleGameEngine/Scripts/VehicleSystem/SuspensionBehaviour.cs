using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem
{
    public class SuspensionBehaviour : MonoBehaviour
    {
        #region Declarations
        [Header("Vehicle Suspension")]
        [Space(2f)]

        [Header("Steering Setup")]
        [SerializeField] float steerAngleStep = 5f;
        [SerializeField] float maxSteerAngle = 45f;

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
            }
            // When not steering at all
            else
            {
                _currentSteerAngle = 0;
            }

            // Finnaly pass steer angle to the axle wheels
            if (Mathf.Floor(Mathf.Abs(_currentSteerAngle)) > 0)
            {
                for (int axis = 0; axis < axleWheels.Length; axis++)
                {
                    axleWheels[axis].steerAngle = _currentSteerAngle;
                }
            }
        }

        // Arcade Steering
        /*private void UpdateSideSpeed(float speedIncrease)
        {
            // When steering then turn the vehicle
            if (speedIncrease != 0)
            {
                currentSteerAngle += speedIncrease * Time.deltaTime;

                if (currentSteerAngle > maxSteerAngle)
                {
                    currentSteerAngle = maxSteerAngle;
                }
                else if (currentSteerAngle < -maxSteerAngle)
                {
                    currentSteerAngle = -maxSteerAngle;
                }
            }
            // When not steering return the vehicle to a straight position
            else
            {
                if (currentSteerAngle < 0)
                {
                    currentSteerAngle += steerForce * Time.deltaTime;
                    if (currentSteerAngle > 0)
                        currentSteerAngle = 0;
                }
                else if (currentSteerAngle > 0)
                {
                    currentSteerAngle -= steerForce * Time.deltaTime;
                    if (currentSteerAngle < 0)
                        currentSteerAngle = 0;
                }
            }
        }*/
        #endregion
    }
}
