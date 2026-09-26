using System.Collections.Generic;
using UnityEngine;

// TODO: Remove this class
[DisallowMultipleComponent]
public class Weapons : MonoBehaviour
{
    [SerializeField] Transform weaponParent;
    [SerializeField] List<SO_WeaponData> availableWeapons;

    void Start()
    {
        foreach(SO_WeaponData weapon in GameStateManager.Instance.UnlockedWeapons)
        {
            weapon.Spawn(weaponParent, this);
        }
    }
}
