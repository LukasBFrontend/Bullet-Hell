using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerWeaponSelector : MonoBehaviour
{
    [SerializeField] Transform weaponParent;
    [SerializeField] List<WeaponData> weapons;
    [Space]
    [Header("Runtime Filled")]
    [SerializeField] List<WeaponData> activeWeapons;
    public List<WeaponData> ActiveWeapons => activeWeapons;

    void Start()
    {
        activeWeapons.Add(weapons[0]);

        if (activeWeapons.Count == 0)
        {
            Debug.Log($"No weapon assigned to active weapons");
            return;
        }

        foreach(WeaponData weapon in activeWeapons)
        {
            weapon.Spawn(weaponParent, this);
        }
    }
}
