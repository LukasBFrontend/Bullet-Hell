using UnityEngine;
using UnityEngine.Events;
public abstract class Character : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] int health;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Collider2D collider;
    [HideInInspector] public UnityEvent<int, int> OnHealthChanged;
    int _maxHealth;
    public Rigidbody2D Rigidbody => rigidbody;
    public Collider2D Collider => collider;
    public int Health => health;
    public int MaxHealth => _maxHealth;

    public void Initialize()
    {
        health = _maxHealth;
    }


    /// <summary>
    /// Subtracts amount from the character health. If it reaches zero, invokes Die().
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, _maxHealth);
        OnHealthChanged.Invoke(health, _maxHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Adds amount to character health up to MaxHealth
    /// </summary>
    /// <param name="amount"></param>
    public void Heal(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, _maxHealth);
    }

    public void ResetHealth()
    {
        health = _maxHealth;
    }
    public abstract void Die();
}
