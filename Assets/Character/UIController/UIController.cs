using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;
using UnityEngine.Windows;

namespace Project.End
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private GameObject pickUpText;
        [SerializeField] private GameObject EnterText;

        private StarterAssetsInputs _input;
        private ThirdPersonController _thirdPersonController; // Reference to camera control script
        private bool isSettingsOpen = false;

        private void Awake()
        {
            // Ensure the UI is hidden at the start
            settingsMenu.SetActive(false);
            pickUpText.SetActive(false);
            EnterText.SetActive(false);

            // Get reference to the StarterAssetsInputs and camera control script
            _input = FindObjectOfType<StarterAssetsInputs>();
            _thirdPersonController = FindObjectOfType<ThirdPersonController>();

            if (_input == null)
            {
                Debug.LogError("StarterAssetsInputs not found! Make sure it's in the scene.");
            }

            if (_thirdPersonController == null)
            {
                Debug.LogError("ThirdPersonController not found! Make sure it's in the scene.");
            }
        }

        private void Update()
        {
            // Check for ESC key press from StarterAssetsInputs
            if (_input != null && _input.esc > 0.5f)
            {
                ToggleSettingsMenu();
                _input.esc = 0f;  // Reset the esc input to avoid multiple triggers
            }
        }

        public void ToggleSettingsMenu()
        {
            isSettingsOpen = !isSettingsOpen;

            settingsMenu.SetActive(isSettingsOpen);

            if (isSettingsOpen)
            {
                // Freeze the game
                Time.timeScale = 0f;
                // Show cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                // Disable camera control
                if (_thirdPersonController != null)
                {
                    _thirdPersonController.enabled = false;
                }
            }
            else
            {
                // Unfreeze the game
                Time.timeScale = 1f;
                // Hide cursor
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                // Enable camera control
                if (_thirdPersonController != null)
                {
                    _thirdPersonController.enabled = true;
                }
            }
        }

        public void ShowPickUpText()
        {
            pickUpText.SetActive(true);
        }

        public void HidePickUpText()
        {
            pickUpText.SetActive(false);
        }

        public void ShowEnterText()
        {
            EnterText.SetActive(true);
        }

        public void HideEnterText()
        {
            EnterText.SetActive(false);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        public void BR_restart()
        {
            SceneManager.LoadScene("BabyRoom");
        }
        public void LR_restart()
        {
            SceneManager.LoadScene("LivingRoom");
        }
        public void PR_restart()
        {
            SceneManager.LoadScene("ParentsRoom");
        }
        public void CB_restart()
        {
            SceneManager.LoadScene("CastleBoss");
        }
        public void WMB_restart()
        {
            SceneManager.LoadScene("WashingMachineBoss");
        }
        public void DB_restart()
        {
            SceneManager.LoadScene("DrawerBoss");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
