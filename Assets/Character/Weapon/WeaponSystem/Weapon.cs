using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.End
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponDataSO weaponData;
        [SerializeField] public UIController uiController; // Reference to the UIController

        private bool isPlayerInRange = false;
        private StarterAssets.StarterAssetsInputs playerInputs;
        private WeaponManager weaponManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                weaponManager = other.GetComponent<WeaponManager>();
                playerInputs = other.GetComponent<StarterAssets.StarterAssetsInputs>();
                if (weaponManager != null && playerInputs != null)
                {
                    isPlayerInRange = true;
                    uiController.ShowPickUpText(); // Show the pickup UI
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
                    uiController.HidePickUpText(); // Hide the pickup UI
                }
            }
        }

        private void Update()
        {
            if (isPlayerInRange && playerInputs.action)
            {
                if (weaponManager != null)
                {
                    weaponManager.EquipWeapon(weaponData);
                    Destroy(gameObject);
                    playerInputs.ActionInput(false);  // Reset the action input after picking up the weapon
                    uiController.HidePickUpText(); // Hide the pickup UI after picking up the weapon
                }
            }
        }
    }
}
