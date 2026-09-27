using UnityEngine;
using Unity.Properties;
using UnityEngine.UIElements;

[System.Serializable]
public enum StatScalingType
{
    Additive,
    Multiplicative,
}

public enum UpgradeType
{
    CharacterStat,
    WeaponUnlock,
    WeaponStat,
}

[CreateAssetMenu(fileName = "UpgradeChoiceData", menuName = "Runtime/UpgradeChoiceData")]
public class SO_UpgradeOptionData : ScriptableObject
{
    [Header("Card data")]
    public UpgradeType upgradeType;
    public Sprite sprite;
    public string title;
    public string metaDescription;
    [Header("Stat data")]
    public StatScalingType scalingType;
    public string statname;
    public float statIncrease;
    public int lvl;
    [Header("Default value")]
    [SerializeField] SO_UpgradeOptionData defaultValues;

    // Scaling type (Additive / Multiplicative)
    [CreateProperty]
    public StyleEnum<DisplayStyle> DisplayAddativeStatType => scalingType == StatScalingType.Additive ? DisplayStyle.Flex : DisplayStyle.None;
    [CreateProperty]
    public StyleEnum<DisplayStyle> DisplayMultiplicativeStatType => scalingType == StatScalingType.Multiplicative ? DisplayStyle.Flex : DisplayStyle.None;

    // Upgrade type (Character / Weapon / WeaponUnlock)
    public StyleEnum<DisplayStyle> DisplayCharacter => upgradeType == UpgradeType.CharacterStat ? DisplayStyle.Flex : DisplayStyle.None;
    public StyleEnum<DisplayStyle> DisplayWeapon => upgradeType == UpgradeType.WeaponStat ? DisplayStyle.Flex : DisplayStyle.None;
    public StyleEnum<DisplayStyle> DisplayWeaponUnlock => upgradeType == UpgradeType.WeaponUnlock ? DisplayStyle.Flex : DisplayStyle.None;

    public void SetValuesCharacterStat(Stat stat)
    {
        upgradeType = UpgradeType.CharacterStat;

        scalingType = stat is AdditiveStat
            ? StatScalingType.Additive
            : StatScalingType.Multiplicative
        ;

        sprite = stat.Sprite;
        title = stat.Name;
        statname = stat.ShortName;
        statIncrease = stat.PerLevelIncrease;
        lvl = stat.Lvl + 1;
    }

    public void SetValuesWeaponUnlock(string weaponName)
    {
        upgradeType = UpgradeType.WeaponUnlock;

        title = weaponName;
        lvl = 1;
    }

    public void SetValuesWeaponStat(string weaponName, Stat stat)
    {
        upgradeType = UpgradeType.WeaponStat;

        scalingType = stat is AdditiveStat
            ? StatScalingType.Additive
            : StatScalingType.Multiplicative
        ;

        sprite = stat.Sprite;
        title = weaponName;
        statname = stat.ShortName;
        statIncrease = stat.PerLevelIncrease;
        lvl = stat.Lvl + 1;
    }
}
