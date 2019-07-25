using UnityEngine;
using NewIndieDev.VehicleGameEngine.InputSystem;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem  
{
    /* Controlls how controllable vehicles should behaviour */
    // Should be attached to a vehicle controlled by the player 
    [RequireComponent(typeof(PowertrainBehaviour))]
    [RequireComponent(typeof(SuspensionBehaviour))]
    [RequireComponent(typeof(BrakeBehaviour))]
    public class VehicleController : MonoBehaviour
    {
        #region Declarations
        // Script references
        PowertrainBehaviour powerTrain;
        SuspensionBehaviour suspension;
        BrakeBehaviour brake;
        #endregion

        #region Main Methods
        // Awake is called once upon scene load
        private void Awake()
        {
            // Get powertrain behaviour script reference
            powerTrain = GetComponent<PowertrainBehaviour>();

            // Get suspension behaviour script reference
            suspension = GetComponent<SuspensionBehaviour>();

            // Get brake behaviour script reference
            brake = GetComponent<BrakeBehaviour>();
        }
        
        // FixedUpdate is called once per fixed frame
        private void FixedUpdate()
        {
            /* TODO test if these should be on Update methods instead for performace */
            
            // If found an input manager instance
            if (InputManager.instance)
            {
                // Wheen player uses the throttle
                powerTrain.ApplyTorqueToWheels(InputManager.instance.throttle);

                // When player steers
                suspension.TurnAxleWheels(InputManager.instance.steerRight - InputManager.instance.steerLeft);

                // Wheen player brakes
                brake.BrakeVehicle(InputManager.instance.brake);

                // When player uses handbrake
                brake.handbrakeVehicle(InputManager.instance.handbrake);
            }
        }
        #endregion
    }
}
