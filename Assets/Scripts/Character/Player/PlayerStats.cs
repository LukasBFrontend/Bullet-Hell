using System.Collections.Generic;

public enum StatName
{
    Damage,
    HP,
    MoveSpeed,
    ProjectileCount,
}

public struct PlayerStats
{
    /// <summary>
    /// Damage multiplier, starting at 1.
    /// </summary>
    public float Damage => EvaluateMultiplierStat(_statLevelLookup[StatName.Damage], _damageScalingIncrement);
    /// <summary>
    /// Hit point multiplier, starting at 1.
    /// </summary>
    public float HP => EvaluateMultiplierStat(_statLevelLookup[StatName.HP], _hpScalingIncrement);
    /// <summary>
    /// Movement speed multiplier, starting at 1.
    /// </summary>
    public float MoveSpeed => EvaluateMultiplierStat(_statLevelLookup[StatName.MoveSpeed], _movementspeedScalingIncrement);
    /// <summary>
    /// Flat projectile count increase, starting at 0.
    /// </summary>
    public int ProjectileCount => EvaluateAddativeStat(_statLevelLookup[StatName.ProjectileCount], _projectileCountIncrease);
    private Dictionary<StatName, int> _statLevelLookup;
    public float _damageScalingIncrement;
    public float _hpScalingIncrement;
    public float _movementspeedScalingIncrement;
    public int _projectileCountIncrease;

    public PlayerStats(LevelScalingData playerStatsData)
    {
        _statLevelLookup = new()
        {
            { StatName.Damage, 1},
            { StatName.HP, 1},
            { StatName.MoveSpeed, 1},
            { StatName.ProjectileCount, 1},
        };

        _damageScalingIncrement = playerStatsData.damageScalingIncrement;
        _hpScalingIncrement = playerStatsData.hpScalingIncrement;
        _movementspeedScalingIncrement = playerStatsData.movementspeedScalingIncrement;
        _projectileCountIncrease = playerStatsData.projectileCountIncrease;
    }

    /// <summary>
    /// Advance the level of a player stat by 1.
    /// </summary>
    /// <param name="statName">The stat to level up.</param>
    public void LvlUpStat(StatName statName)
    {
        _statLevelLookup[statName] += 1;
    }

    private float EvaluateMultiplierStat(int statLvl, float percentScalingIncrement)
    {
        return 1 + ((statLvl - 1) * percentScalingIncrement / 100);
    }

    private int EvaluateAddativeStat(int statLvl, int projectileIncrease)
    {
        return statLvl * projectileIncrease;
    }
}
