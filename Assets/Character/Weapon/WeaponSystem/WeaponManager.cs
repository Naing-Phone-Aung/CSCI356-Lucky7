using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.End
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField]
        private Transform swordHolderSlot; 
        [SerializeField]
        private Transform axeHolderSlot; 
        [SerializeField]
        private Transform TaxeHolderSlot;

        private GameObject currentSword;
        private GameObject currentAxe;
        private GameObject currentTaxe;

        [SerializeField]
        public WeaponDataSO equippedWeapon;

        public void EquipWeapon(WeaponDataSO weaponData)
        {
            equippedWeapon = weaponData;

            // Determine which slot to use based on the weapon name or type
            if (weaponData.weaponName == "Sword")
            {
                // Destroy the current sword if there is one
                if (currentSword != null)
                {
                    Destroy(currentSword);
                }
                // Instantiate and place the new sword in the sword slot
                currentSword = Instantiate(weaponData.weaponPrefab);
                currentSword.transform.SetParent(swordHolderSlot);
                currentSword.transform.localPosition = Vector3.zero;
                currentSword.transform.localRotation = Quaternion.identity;
            }
            else if (weaponData.weaponName == "Axe")
            {
                // Destroy the current axe if there is one
                if (currentAxe != null)
                {
                    Destroy(currentAxe);
                }
                // Instantiate and place the new axe in the axe slot
                currentAxe = Instantiate(weaponData.weaponPrefab);
                currentAxe.transform.SetParent(axeHolderSlot);
                currentAxe.transform.localPosition = Vector3.zero;
                currentAxe.transform.localRotation = Quaternion.identity;
            }

            else if (weaponData.weaponName == "ThorAxe")
            {
                // Destroy the current axe if there is one
                if (currentTaxe != null)
                {
                    Destroy(currentTaxe);
                }
                // Instantiate and place the new axe in the axe slot
                currentTaxe = Instantiate(weaponData.weaponPrefab);
                currentTaxe.transform.SetParent(axeHolderSlot);
                currentTaxe.transform.localPosition = Vector3.zero;
                currentTaxe.transform.localRotation = Quaternion.identity;
            }
        }
    }
}
