using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerWeaponSelector : MonoBehaviour
{
    [SerializeField] Transform weaponParent;
    [SerializeField] List<WeaponScriptableObject> weapons;
    [Space]
    [Header("Runtime Filled")]
    [SerializeField] List<WeaponScriptableObject> activeWeapons;
    public List<WeaponScriptableObject> ActiveWeapons { get { return activeWeapons; }}

    void Start()
    {
        activeWeapons.Add(weapons[0]);

        if (activeWeapons.Count == 0)
        {
            Debug.Log($"No weapon assigned to active weapons");
            return;
        }

        foreach(WeaponScriptableObject weapon in activeWeapons)
        {
            weapon.Unlock(weaponParent, this);
        }
    }
}
