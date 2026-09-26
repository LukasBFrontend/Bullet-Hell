
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The player stats component.
/// </summary>
public class Stats : MonoBehaviour
{
    [SerializeField] SO_WeaponsConfig weaponsConfig;
    [SerializeField] SO_CharacterStatsConfig playerStatsConfig;
    public CharacterStats CharacterStats => _characterStats;
    CharacterStats _characterStats;
    Dictionary<string, WeaponStats> _weaponsStatsLookUp;

    public WeaponStats WeaponStats(string weaponName)
    {
        bool statsExist = _weaponsStatsLookUp.TryGetValue(weaponName, out var weaponStats);

        if (!statsExist)
        {
            throw new System.Exception($"WeaponStats for weapon with name: '{weaponName}' does not exist in {nameof(Stats)}");
        }

        return weaponStats;
    }

    private void Awake()
    {
        _characterStats = new CharacterStats(playerStatsConfig);

        WeaponStats[] weaponStats = weaponsConfig.availableWeapons.Select(
            weaponData => new WeaponStats(weaponData.WeaponName, weaponData.Stats)
        ).ToArray();

        _weaponsStatsLookUp = weaponStats.ToDictionary(stats => stats.WeaponName);

        _characterStats.DamageMultiplier.LevelUp();
    }
}
