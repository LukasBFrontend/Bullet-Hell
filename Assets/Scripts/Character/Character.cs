using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Health))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Collider2D collider;
    [SerializeField] Health healthScript;
    public Rigidbody2D Rigidbody => rigidbody;
    public Collider2D Collider => collider;
    public Health Health => healthScript;
    public abstract void Die();
}
