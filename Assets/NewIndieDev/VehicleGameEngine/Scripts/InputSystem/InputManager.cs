using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        #region Declarations
        [Header("Vehicle Setup")]
        [Space(2f)]

        [Header("Steer Input")]
        public float steerLeft;
        [SerializeField] ControllerInput steerLeftInput;
        public float steerRight;
        [SerializeField] ControllerInput steerRightInput;

        [Header("Throttle Input")]
        public float throttle;
        [SerializeField] ControllerInput throttleInput;

        [Header("Brake Input")]
        public float brake;
        [SerializeField] ControllerInput brakeInput;

        [Header("Handbrake Input")]
        public float handbrake;
        [SerializeField] ControllerInput handBrakeInput;
        #endregion

        #region Main Methods
        // Update is called once per frame
        void Update()
        {
            GetInput();

            throttle = GetVehicleInput(throttleInput);
            handbrake = GetVehicleInput(handBrakeInput);
        }

        #endregion

        #region  Helper Methods
        // Get vehicle input from player
        private float GetVehicleInput(ControllerInput gameInput)
        {
            float _inputValue = 0;

            if (!gameInput.buttonName.Equals(""))
            {
                if (Input.GetButton(gameInput.buttonName))
                {
                    _inputValue = 1;
                }
            }

            if (!gameInput.axisName.Equals(""))
            {
                if (Input.GetAxisRaw(gameInput.axisName) > gameInput.axisDeadzone)
                {
                    _inputValue = Input.GetAxisRaw(gameInput.axisName);
                }
            }

            return Mathf.Abs(_inputValue);
        }

        //
        private void GetInput()
        {
            if (Input.GetAxisRaw("Horizontal") > 0.1f)
            {
                steerRight = Input.GetAxisRaw("Horizontal");
            }
            else
            {
                steerRight = 0;
            }

            if (Input.GetAxisRaw("Horizontal") < -0.1f)
            {
                steerLeft = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
            }
            else
            {
                steerLeft = 0;
            }

            /*
            if (Input.GetAxisRaw("Vertical") > 0.1f)
            {
                throttle = Input.GetAxisRaw("Vertical");
            }
            else
            {
                throttle = 0;
            }
            */

            if (Input.GetAxisRaw("Vertical") < -0.1f)
            {
                brake = Input.GetAxisRaw("Vertical");
            }
            else
            {
                brake = 0;
            }

            /*
            if (Input.GetButton("Jump"))
            {
                handbrake = 1;
            }
            else
            {
                handbrake = 0;
            }
            */
        }
        #endregion
    }
}
