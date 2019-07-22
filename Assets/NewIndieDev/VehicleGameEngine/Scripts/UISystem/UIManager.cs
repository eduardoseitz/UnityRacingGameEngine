using UnityEngine;
using UnityEngine.UI;
using NewIndieDev.VehicleGameEngine.VehicleSystem;

namespace NewIndieDev.VehicleGameEngine.UISystem
{
    public class UIManager : MonoBehaviour
    {
        #region Declarations
        // Static singleton property
        public static UIManager instance { get; private set; }

        [Header("HUD Dash")]
        [Space(2f)]
        [SerializeField] Text speedometerText;
        #endregion

        #region Main Methods
        #endregion

        #region Helper Methods
        // Update speedometer on the screen
        public void UpdateSpeedometer(float speed)
        {
            speedometerText.text = Mathf.Abs(speed).ToString("0") + "Km/h";
        }
        #endregion
    }
}
