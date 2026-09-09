using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAction : MonoBehaviour
{
    [SerializeField] PlayerWeaponSelector weaponSelector;

    void Update()
    {
        foreach(WeaponScriptableObject weapon in weaponSelector.ActiveWeapons)
        {
            weapon.Attack();
        }
    }
}
