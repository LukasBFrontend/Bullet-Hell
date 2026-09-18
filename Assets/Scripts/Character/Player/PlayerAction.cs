using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAction : MonoBehaviour
{
    [SerializeField] PlayerWeaponSelector weaponSelector;

    void Update()
    {
        foreach(WeaponData weapon in weaponSelector.ActiveWeapons)
        {
            weapon.Attack();
        }
    }
}
