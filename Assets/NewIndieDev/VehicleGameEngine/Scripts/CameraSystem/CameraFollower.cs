using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewIndieDev.VehicleGameEngine.CameraSystem
{
    public class CameraFollower : MonoBehaviour
    {
        #region Declarations
        [Header("Camera Views")]
        [SerializeField] int currentView;
        [SerializeField] CameraView[] cameraViews;

        Vector3 _currentPosition;
        Quaternion _currentRotation;
        
        #endregion

        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            ResetCamera();
        }

        // FixedUpdate is called once per fixed frame
        void FixedUpdate()
        {

        }
        
        // Update is called once per frame
        void Update()
        {
            GetTargetPosition();
            FollowTargetPosition();

            GetTargetRotation();
            FollowTargetRotation();
            
            /* TODO Switch between cameras using InputSystem */
            if (Input.GetKeyDown("c"))
            {
                CycleView(cameraViews[currentView]);
            }
        }

        // LateUpdate is called after every frame
        void LateUpdate()
        {
            GetTargetPosition();
            FollowTargetPosition();

            GetTargetRotation();
            FollowTargetRotation();
        }
        #endregion

        #region HelperMethods
        // Cycle between view cameras
        private void CycleView(CameraView view)
        {
            if (currentView < cameraViews.Length - 1) 
            {
                currentView++;
            }
            else
            {
                currentView = 0;
            }
        }

        private void ResetCamera()
        {
            GetTargetPosition();
            GetTargetRotation();
        }

        //
        private void GetTargetPosition()
        {
            _currentPosition = cameraViews[currentView].targetTransform.position;
        }

        //
        private void FollowTargetPosition()
        {
            transform.position = _currentPosition;
        }

        //
        private void GetTargetRotation()
        {
            _currentRotation = cameraViews[currentView].targetTransform.rotation;
        }

        //
        private void FollowTargetRotation()
        {
            transform.rotation = _currentRotation;
        }
        #endregion
    }
}
