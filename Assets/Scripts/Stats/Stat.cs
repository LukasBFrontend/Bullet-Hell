using UnityEngine;

public abstract class Stat
{
    public int Lvl => _lvl;
    public Sprite Sprite => _sprite;
    public string Name => _name;
    public string ShortName => _shortName;
    public float PerLevelIncrease => _perLevelIncrease;
    protected Sprite _sprite;
    protected string _name;
    protected string _shortName;
    protected int _lvl;
    protected float _perLevelIncrease;

    /// <summary>
    /// Advance the stat's lvl by one.
    /// </summary>
    /// <returns>The new lvl.</returns>
    public int LevelUp()
    {
        return _lvl++;
    }

}

/// <summary>
/// A stat which is meant to scale via a flat per-level increase.
/// </summary>
public class AdditiveStat : Stat
{
    /// <summary>
    /// Stat increase, starting at 0 at lvl 1.
    /// </summary>
    public float BaseValue => _baseValue;
    public float Value => _baseValue + NetIncrease();
    private float _baseValue;

    public AdditiveStat(AdditiveStatData statData)
    {
        _sprite = statData.UISprite;
        _name = statData.name;
        _shortName = statData.shortName;
        _baseValue = statData.baseValue;
        _perLevelIncrease = statData.flatScaling;
    }

    public float NetIncrease()
    {
        return  _lvl * _perLevelIncrease;
    }
}

/// <summary>
/// A stat which is meant to scale via a multiplier.
/// </summary>
public sealed class MultiplicativeStat : Stat
{
    /// <summary>
    /// Stat multiplier, starting at 1f at lvl 1.
    /// </summary>
    public float MultiplierValue => EvaluateMultiplicativeStat(Lvl, _perLevelIncrease);

    public MultiplicativeStat(MultiplicativeStatData statData)
    {
        _sprite = statData.UISprite;
        _name = statData.name;
        _shortName = statData.shortName;
        _perLevelIncrease = statData.multiplierScaling;
    }
    private float EvaluateMultiplicativeStat(int lvl, float percentMultiplierIncrease)
    {
        return 1f + ((lvl - 1) * percentMultiplierIncrease / 100f);
    }
}
