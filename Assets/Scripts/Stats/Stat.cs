using UnityEngine;

public abstract class Stat
{
    public int Lvl => _lvl;
    public Sprite Sprite => _sprite;
    public string Name => _name;
    public string ShortName => _shortName;
    protected Sprite _sprite;
    protected string _name;
    protected string _shortName;
    private int _lvl;

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
    public int BaseValue => _baseValue;
    public int Increase => Lvl * _perLevelIncrease;
    private int _perLevelIncrease;
    private int _baseValue;

    public AdditiveStat(AdditiveStatData statData)
    {
        _sprite = statData.UISprite;
        _name = statData.name;
        _shortName = statData.shortName;
        _baseValue = statData.baseValue;
        _perLevelIncrease = statData.flatScaling;
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
    public float Multiplier => EvaluateMultiplicativeStat(Lvl, _percentScalingIncrease);
    private float _percentScalingIncrease;

    public MultiplicativeStat(MultiplicativeStatData statData)
    {
        _sprite = statData.UISprite;
        _name = statData.name;
        _shortName = statData.shortName;
        _percentScalingIncrease = statData.multiplierScaling;
    }
    private float EvaluateMultiplicativeStat(int lvl, float percentMultiplierIncrease)
    {
        return 1f + ((lvl - 1) * percentMultiplierIncrease / 100f);
    }
}
