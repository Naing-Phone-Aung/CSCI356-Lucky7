using Project.End;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BLtoLR : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    private StarterAssets.StarterAssetsInputs playerInputs;
    private WeaponManager weaponManager;
    private bool isPlayerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        uiController.HideEnterText(); // Ensure the UI is hidden at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && playerInputs.action)
        {
            if (weaponManager != null && weaponManager.equippedWeapon != null && weaponManager.equippedWeapon.weaponName == "Sword")
            {
                SceneManager.LoadScene("LivingRoom");
            }
            playerInputs.ActionInput(false);  // Reset the action input after entering the castle
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            weaponManager = other.GetComponent<WeaponManager>();
            playerInputs = other.GetComponent<StarterAssets.StarterAssetsInputs>();
            if (weaponManager != null && playerInputs != null)
            {
                isPlayerInRange = true;
                uiController.ShowEnterText(); // Show the "Enter" UI
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<WeaponManager>() == weaponManager)
            {
                isPlayerInRange = false;
                weaponManager = null;
                playerInputs = null;
                uiController.HideEnterText(); // Hide the "Enter" UI
            }
        }
    }
}
