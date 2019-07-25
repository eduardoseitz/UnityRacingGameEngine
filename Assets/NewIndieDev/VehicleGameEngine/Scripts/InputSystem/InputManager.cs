using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        #region Declarations
        // Static singleton property
        public static InputManager instance { get; private set; } 

        [Header("Vehicle Input Setup")]
        [Space(2f)]

        [Header("Steer Input")]
        public float steerLeft;
        [SerializeField] GameInput steerLeftInput;
        public float steerRight;
        [SerializeField] GameInput steerRightInput;

        [Header("Throttle Input")]
        public float throttle;
        [SerializeField] GameInput throttleInput;

        [Header("Brake Input")]
        public float brake;
        [SerializeField] GameInput brakeInput;

        [Header("Handbrake Input")]
        public float handbrake;
        [SerializeField] GameInput handBrakeInput;
        #endregion

        #region Main Methods
        private void Awake()
        {
            // Check if there are any other instances conflicting
            if (instance != null && instance != this)
            {
                // If that is the case, we destroy other instances
                Destroy(gameObject);
            }

            // Save a reference to the component as our singleton instance
            instance = this;

            // Make sure that we don't destroy between scenes (this is optional)
            DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            // Get and store player input about vehicle controll
            GetVehicleInput(steerLeftInput, ref steerLeft);
            GetVehicleInput(steerRightInput, ref steerRight);
            GetVehicleInput(throttleInput, ref throttle);
            GetVehicleInput(brakeInput, ref brake);
            GetVehicleInput(handBrakeInput, ref handbrake);
        }
        #endregion

        #region  Helper Methods
        // Get vehicle input from player
        private void GetVehicleInput(GameInput gameInput, ref float valueOutput)
        {
            // If game input is valid
            if (!gameInput.inputName.Equals(""))
            {
                // If is not an axis type input
                if (!gameInput.isAxis)
                {
                    // If button is pressed
                    if (Input.GetButton(gameInput.inputName))
                    {
                        valueOutput = 1;
                    }
                    else
                    {
                        valueOutput = 0;
                    }
                }
                // If is an axis type input
                else
                {
                    // If axis is moved more than its deadzone and is not inverted
                    if ((Input.GetAxisRaw(gameInput.inputName) > gameInput.axisDeadzone && !gameInput.isAxisInverted) || (Input.GetAxisRaw(gameInput.inputName) < -gameInput.axisDeadzone && gameInput.isAxisInverted))
                    {
                        valueOutput = Mathf.Abs(Input.GetAxisRaw(gameInput.inputName));
                    }
                    else
                    {
                        valueOutput = 0;
                    }
                }
            }
        }
        #endregion
    }
}
