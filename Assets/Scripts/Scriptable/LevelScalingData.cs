using UnityEngine;

[CreateAssetMenu(fileName = "LevelScalingData", menuName = "Player/LevelScalingData")]
public class LevelScalingData : ScriptableObject
{
    [Tooltip("How many percentiles should the stat scale per level?")]
    [Range(0, 50)]
    public int damageScalingIncrement;
    [Tooltip("How many percentiles should the stat scale per level?")]
    [Range(0, 50)]
    public int hpScalingIncrement;
    [Tooltip("How many percentiles should the stat scale per level?")]
    [Range(0, 50)]
    public int movementspeedScalingIncrement;
    [Tooltip("How many projectiles should be added to attacks per level?")]
    public int projectileCountIncrease;
}
