using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewIndieDev.VehicleGameEngine.Math;
using NewIndieDev.VehicleGameEngine.InputSystem;

namespace NewIndieDev.VehicleGameEngine.VehicleSystem  
{
    /* Controlls how controllable vehicles should behaviour */
    // Should be attached to a vehicle controlled by the player 
    public class VehicleController : MonoBehaviour
    {
        #region Declarations
        [Header("Vehicle Properties")]
        [Space(2f)]

        #region Longtitudinal Forces
        [Header("Vehicle Foward Forces")]

        /*[HideInInspector] */ public float currentStraightSpeed;
        [Tooltip("Max vehicle speed in Km/h.")]
        [SerializeField] float maxSpeed = 120f;
        [Tooltip("Max vehicle speed in Km/h.")]
        [SerializeField] float maxReverseSpeed = 40f; 
        [Tooltip("Aceleration of this vehicle in Km/h.")]
        [SerializeField] float accelerationForce = 20f;
        [Tooltip("Aceleration of this vehicle in Km/h.")]
        [SerializeField] float reverseForce = 15f;
        [Tooltip("How fast does this vehicle's brakes in Km/h.")]
        [SerializeField] float brakeForce = 25f;
        [Tooltip("How fast does this vehicle's brakes in Km/h.")]
        [SerializeField] float handBrakeForce = 50f;
        [Tooltip("Decrement of the speed when not acelerating in Km/h.")]
        /*[HideInInspector]*/ [SerializeField] float airResistenceForce = 3f;
        [SerializeField] float groundResistenceForce = 5f;
        [Space(2f)]
        #endregion

        #region Lateral Forces
        [Header("Vehicle Side Forces")]

        /*[HideInInspector]*/ public float currentSteerAngle;
        [Tooltip("How much can this vehicle turn in Degree.")]
        [SerializeField] float maxSteerAngle = 40f;
        [Tooltip("How fast does this vehicle turns in Degree/s.")]
        [SerializeField] float steerForce = 75f;
        [Tooltip("Decrement of the speed while turning in Km/h.")]
        [SerializeField] float steerResistenceForce = 0.5f;
        [Space(2f)]
        #endregion

        #region Visual Elements
        [Header("Vehicle Wheels")]
            
        [SerializeField] Wheel[] wheels;
        [SerializeField] Transform[] leftAxleWheels;
        [SerializeField] Transform[] rightAxleWheels;
        [SerializeField] Transform[] poweredWheels;
        [Space(2f)]
        #endregion

        // Script References
        DataConverter dataConverter = new DataConverter();
        InputManager inputManager;

        Transform _currentSteerAxis;
        #endregion

        #region Main Methods

        #region Start Methods
        private void Awake() {
            inputManager = FindObjectOfType<InputManager>();

            // Instantiate visual wheel models
            foreach(Wheel vehicleWheel in wheels)
                InstantiateWheelModel(vehicleWheel);
        }
        #endregion

        #region Update Methods
        // FixedUpdate is called once per fixed frame
        private void FixedUpdate()
        {
            // Steer vehicle around axis
            TurnVehicle();

            // Apply acceleration force to the vehicle
            AccelerateVehicle();

            // Appy side resistance force to the vehicle
            ApplySideResistanceForce();

            // Apply desaceleration force to the vehicle
            DesacelerateVehicle();

            // Apply air and ground resistance forces to the vehicle
            ApplyStraightResistanceForce();
        }

        // Update is called once per frame
        private void Update()
        {
            // Steer the wheel axle visually
            foreach (Transform axis in leftAxleWheels)
                SteerWheelModel(axis);
            foreach (Transform axis in rightAxleWheels)
                SteerWheelModel(axis);

            // Spin wheel model visually
            foreach (Wheel wheel in wheels)
                SpinWheelModel(wheel.centerTransform.gameObject);
        }
        #endregion
            
        #endregion

        #region Helper Methods
            
        #region Straight Forces Methods
        // Updates the vehicle currentSpeed prarameter
        private void UpdateStraightSpeed(float speedIncrease)
        {
            // Increases or decreases vehicle acceleration force
            currentStraightSpeed += dataConverter.KilometersByHoursToMetersBySecond(speedIncrease) * Time.deltaTime;

            // Limits vehicle speed by its maxSpeed parameter 
            if (currentStraightSpeed > maxSpeed)
                currentStraightSpeed = maxSpeed;

            if (currentStraightSpeed < -Mathf.Abs(maxReverseSpeed))
                currentStraightSpeed = -Mathf.Abs(maxReverseSpeed);
        }
            
        // Update current vehicle speed based on acceleration
        private void AccelerateVehicle()
        {
            /* TODO switch to wheel colliders */
            /* TODO simulate torque */

            // When the gas pedal is pressed increase speed
            if (inputManager.throttle != 0)
            {
                UpdateStraightSpeed(accelerationForce);
            }

            // Finnaly move vehicle
            transform.Translate(0, 0, currentStraightSpeed * Time.deltaTime);
        }

        // Apply forces backwards into the vehicle
        private void DesacelerateVehicle()
        {
            // When the brake pedal is pressed
            if (inputManager.brake != 0)
            {
                // When its braking apply brake force to stop the vehicle
                if (currentStraightSpeed > 0)
                {
                    UpdateStraightSpeed(-brakeForce);
                }
                // When its reversing apply accleration force to reverse the vehicle
                else {
                    UpdateStraightSpeed (-reverseForce);
                }
            }

            // When the handbrake is pulled
            if (inputManager.handbrake != 0)
            {
                if (currentStraightSpeed > 0)
                {
                    UpdateStraightSpeed(-handBrakeForce);
                }
                else
                {
                    UpdateStraightSpeed(handBrakeForce);
                }
            }
        }

        // Apply foward resistence force when its moving
        private void ApplyStraightResistanceForce()
        {
            /* TODO Calculate groundResistanceForce based on what kind of ground the vehicle is riding on */

            // Calculate the drag caused by air resistance
            float _dragResistenceForce = airResistenceForce * Mathf.Abs(currentStraightSpeed);
            float _resistenceForce = airResistenceForce + groundResistenceForce;

            if (currentStraightSpeed >= _resistenceForce)
                UpdateStraightSpeed(-_resistenceForce);
            else if (currentStraightSpeed <= (-_resistenceForce))
                //UpdateStraightSpeed(_resistenceForce);
                
            // Comment the line below if you want inertia at really slow speeds
            if (inputManager.throttle == 0 && (currentStraightSpeed < 1 && currentStraightSpeed > -1)) currentStraightSpeed = 0;
        }
        #endregion

        #region Lateral Forces Methods
        // Update vehicle rotation speed
        private void UpdateSideSpeed(float speedIncrease)
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
        }

        // Turn vehicle based on steering input
        private void TurnVehicle()
        {
            // When steering left and going foward
            if (inputManager.steerLeft != 0 && currentStraightSpeed > 0)
            {
                UpdateSideSpeed(-Mathf.Abs(inputManager.steerLeft) * steerForce);
                _currentSteerAxis = leftAxleWheels[0];
            }
            // When steering left and going backwards
            else if (inputManager.steerLeft != 0 && currentStraightSpeed < 0)
            {
                UpdateSideSpeed(Mathf.Abs(inputManager.steerLeft) * steerForce);
                _currentSteerAxis = leftAxleWheels[0];
            }
            // When steering right and going foward
            else if (inputManager.steerRight != 0 && currentStraightSpeed > 0)
            {
                UpdateSideSpeed(Mathf.Abs(inputManager.steerRight) * steerForce);
                _currentSteerAxis = rightAxleWheels[0];
            }
            // When steering right and going backwards
            else if (inputManager.steerRight != 0 && currentStraightSpeed < 0)
            {
                UpdateSideSpeed(-Mathf.Abs(inputManager.steerRight) * steerForce);
                _currentSteerAxis = rightAxleWheels[0];  
            }
            // When not steering at all
            else
            {
                UpdateSideSpeed(0);
            }

            // Finnaly rotate vehicle
            if (_currentSteerAxis && Mathf.Floor(Mathf.Abs(currentStraightSpeed)) > 0)
            {
                transform.RotateAround(_currentSteerAxis.position, Vector3.up, currentSteerAngle * Time.deltaTime);
            }
        }

        // Apply Lateral Resistance Force
        private void ApplySideResistanceForce()
        {
            // If it is turning
            if (currentSteerAngle != 0)
            {
                // Calculate lateral drag based on straight speed
                float lateralDrag = steerResistenceForce * currentStraightSpeed;

                // Apply side resistence force
                if (currentStraightSpeed > 1)
                    UpdateStraightSpeed(-Mathf.Abs(lateralDrag));
                else if (currentStraightSpeed < -1)
                    UpdateStraightSpeed(Mathf.Abs(lateralDrag));
            }
        }
        #endregion

        #region Visual Changes Methods
        // Instantiate a gameObject as a child to the wheel transform so that it can be visualized
        private void InstantiateWheelModel(Wheel wheel)
        {
            if (wheel.wheelModel)
            {
                GameObject wheelModel = Instantiate(wheel.wheelModel, wheel.centerTransform);
                wheelModel.transform.rotation = wheel.centerTransform.rotation;
                wheelModel.transform.SetParent(wheel.centerTransform);
            }
            else
            {
                Debug.LogError("No wheel model found!");
            }
        }

        // Steer the wheels models visually
        private void SteerWheelModel(Transform wheel)
        {
            /* TODO Rotate wheel visually */
                
            /*if (currentSteerAngle > 0 && wheel.transform.rotation.z <= maxSteerAngle - steerForce)
                wheel.transform.Rotate(0, 0, steerForce * Time.deltaTime);
            else if (currentSteerAngle < 0 && wheel.transform.rotation.z <= maxSteerAngle + steerForce)
                wheel.transform.Rotate(0, 0, -steerForce * Time.deltaTime);*/
        }

        // Spin wheels visually
        private void SpinWheelModel(GameObject wheel)
        {
            wheel.GetComponentInChildren<Transform>().transform.Rotate(0, currentStraightSpeed * Mathf.PI * 10 * Time.deltaTime, 0, Space.Self);
    }
        #endregion

        #endregion
    }
}
