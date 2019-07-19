using UnityEngine;
using UnityEngine.UI;
using NewIndieDev.VehicleGameEngine.VehicleSystem;

namespace NewIndieDev.VehicleGameEngine.UISystem
{
    public class UIManager : MonoBehaviour
    {
        #region Declarations
        [Header("HUD Elemets")]
        [Space(2f)]
        [SerializeField] Text speedometerText;

        // Script references
        VehicleController vehicleController;
        #endregion

        #region Main Methods
        private void Awake() {
            vehicleController = FindObjectOfType<VehicleController>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            ResetHUD();
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateHUD();
        }
        #endregion

        #region Helper Methods
        //
        private void ResetHUD(){}

        //
        private void UpdateHUD()
        {
            speedometerText.text = Mathf.Abs(vehicleController.currentStraightSpeed).ToString("0") + "Km/h";
        }
        #endregion
    }
}
