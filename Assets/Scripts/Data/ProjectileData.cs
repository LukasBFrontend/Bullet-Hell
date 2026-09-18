using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Weapons/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [Range(.1f, 200f)]
    [SerializeField] float initialVelocity;
}
