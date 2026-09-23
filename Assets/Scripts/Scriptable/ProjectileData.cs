using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Weapons/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    public Sprite sprite;
    [Range(.1f, 200f)]
    public float initialVelocity;
}
