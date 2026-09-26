using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    [SerializeField] SO_WeaponsConfig weaponsConfig;
    public Player Player => _player;
    public HashSet<SO_WeaponData> AvailableWeapons => weaponsConfig.availableWeapons.ToHashSet();
    public HashSet<SO_WeaponData> UnlockedWeapons => _unlockedWeapons;
    HashSet<SO_WeaponData> _unlockedWeapons;
    Player _player;

    void OnEnable()
    {
        _player = FindAnyObjectByType<Player>();
        _unlockedWeapons = new (){ weaponsConfig.availableWeapons.First() };
    }

    public void UnlockWeapon(string weaponName)
    {
        SO_WeaponData weapon = weaponsConfig.availableWeapons.First(weapon => weapon.WeaponName == weaponName);

        if (weapon == null)
        {
            throw new System.Exception($"Weapon '{weaponName}' is not in the list of available weapons");
        }
        _unlockedWeapons.Add(weapon);
    }
}
