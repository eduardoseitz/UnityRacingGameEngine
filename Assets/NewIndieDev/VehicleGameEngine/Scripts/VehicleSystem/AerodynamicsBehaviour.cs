using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem
{
    //
    public class AerodynamicsBehaviour : MonoBehaviour
    {
        #region Declarations

        #endregion

        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Helper Methods
        // Apply foward resistence force when its moving
        /*private void ApplyStraightResistanceForce()
        {
            /* TODO Calculate groundResistanceForce based on what kind of ground the vehicle is riding on */
        /*
        // Calculate the drag caused by air resistance
        float _dragResistenceForce = airResistenceForce * Mathf.Abs(currentSpeed);
        float _resistenceForce = airResistenceForce + groundResistenceForce;

        if (currentSpeed >= _resistenceForce)
            powerTrain.ApplyTorque(-_resistenceForce);
        else if (currentSpeed <= (-_resistenceForce))
            //_powerTrain.UpdateStraightSpeed(_resistenceForce);

        // Comment the line below if you want inertia at really slow speeds
        if (InputManager.instance.throttle == 0 && (currentSpeed < 1 && currentSpeed > -1)) currentSpeed = 0;

    }*/

        // Apply Lateral Resistance Force
        /*private void ApplySideResistanceForce()
        {
            // If it is turning
            if (currentSteerAngle != 0)
            {
                // Calculate lateral drag based on straight speed
                float lateralDrag = steerResistenceForce * currentSpeed;

                // Apply side resistence force
                if (currentSpeed > 1)
                    powerTrain.ApplyTorque(-Mathf.Abs(lateralDrag));
                else if (currentSpeed < -1)
                    powerTrain.ApplyTorque(Mathf.Abs(lateralDrag));
            }
        }*/
        #endregion
    }
}
