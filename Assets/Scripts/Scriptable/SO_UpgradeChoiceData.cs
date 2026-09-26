using UnityEngine;
using Unity.Properties;
using UnityEngine.UIElements;

[System.Serializable]
public enum UpgradeStatType
{
    Addative,
    Multiplicative,
}

public enum StatContextType
{
    Character,
    Weapon,
}

[CreateAssetMenu(fileName = "UpgradeChoiceData", menuName = "Runtime/UpgradeChoiceData")]
public class SO_UpgradeOptionData : ScriptableObject
{
    [Header("Card data")]
    public UpgradeStatType upgradeType;
    public StatContextType contextType;
    public Sprite sprite;
    public string title; // Character stat name or weapon name
    [Header("Stat data")]
    public string statname;
    public float statIncrease;
    public int lvl;

    // Convert enum value to be read as booleans
    [CreateProperty]
    public StyleEnum<DisplayStyle> DisplayAddativeStatType => upgradeType == UpgradeStatType.Addative ? DisplayStyle.Flex : DisplayStyle.None;
    [CreateProperty]
    public StyleEnum<DisplayStyle> DisplayMultiplicativeStatType => upgradeType == UpgradeStatType.Multiplicative ? DisplayStyle.Flex : DisplayStyle.None;

    public void Initialize(Stat stat, StatContextType contextType)
    {
        this.contextType = contextType;

        upgradeType = stat is AdditiveStat
            ? UpgradeStatType.Addative
            : UpgradeStatType.Multiplicative
        ;

        sprite = stat.Sprite;
        title = stat.Name;
        statname = stat.ShortName;
        statIncrease = stat.PerLevelIncrease;
        lvl = stat.Lvl + 1;
    }

    public void Initialize(Stat stat, StatContextType contextType, string weaponName)
    {
        this.contextType = contextType;

        upgradeType = stat is AdditiveStat
            ? UpgradeStatType.Addative
            : UpgradeStatType.Multiplicative
        ;

        sprite = stat.Sprite;
        title = weaponName;
        statname = stat.ShortName;
        statIncrease = stat.PerLevelIncrease;
        lvl = stat.Lvl + 1;
    }

    public void Assign(SO_UpgradeOptionData instance)
    {
        contextType = instance.contextType;
        upgradeType = instance.upgradeType;
        sprite = instance.sprite;
        title = instance.title;
        statname = instance.statname;
        statIncrease = instance.statIncrease;
        lvl = instance.lvl;
    }



}
