using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeOptionManager : Singleton<UpgradeOptionManager>
{
    [SerializeField] SO_UpgradeOptionData optionOneData;
    [SerializeField] SO_UpgradeOptionData optionTwoData;
    [SerializeField] SO_UpgradeOptionData optionThreeData;
    List<SO_UpgradeOptionData> _currentOptions = new();

    public void AssignRandom()
    {
        RefreshOptions();

        var numbers = Enumerable.Range(0, _currentOptions.Count)
            .OrderBy(_ => UnityEngine.Random.value)
            .Take(3)
            .ToArray()
        ;

        optionOneData.Assign(_currentOptions[numbers[0]]);
        optionTwoData.Assign(_currentOptions[numbers[1]]);
        optionThreeData.Assign(_currentOptions[numbers[2]]);
    }

    void RefreshOptions()
    {
        Player player = GameStateManager.Instance.Player;

        _currentOptions.Clear();
        var characterStats = player.Stats.Character.All();
        var weaponsStats = player.Stats.Weapons;

        foreach (var (weaponName, weaponStats) in weaponsStats)
        {
            // If weapon is lvl 0 create weapon unlock option and continue
            foreach (var stat in weaponStats.All())
            {
                var option = (SO_UpgradeOptionData)ScriptableObject.CreateInstance(typeof (SO_UpgradeOptionData));
                option.Initialize(stat, StatContextType.Weapon, weaponName);
                _currentOptions.Add(option);
            }
        }

        foreach (var stat in characterStats)
        {
            var option = (SO_UpgradeOptionData)ScriptableObject.CreateInstance(typeof (SO_UpgradeOptionData));
            option.Initialize(stat, StatContextType.Character);
            _currentOptions.Add(option);
        }
    }

    void Start()
    {
        AssignRandom();
    }
}
