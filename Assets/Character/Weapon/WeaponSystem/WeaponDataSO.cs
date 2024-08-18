using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.End
{
    [CreateAssetMenu(menuName = "Data/WeaponData")]
    public class WeaponDataSO : ScriptableObject
    {
        public int damage;
        public string weaponName;
        public GameObject weaponPrefab;
    }
}
