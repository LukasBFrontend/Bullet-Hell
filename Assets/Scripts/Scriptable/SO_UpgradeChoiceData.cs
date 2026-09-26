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
public class SO_UpgradeChoiceData : ScriptableObject
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

    public void Assign(StatData statData, UpgradeStatType upgradeStatType, StatContextType statContextType)
    {

    }

}
