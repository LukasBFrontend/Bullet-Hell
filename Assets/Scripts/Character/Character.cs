using UnityEngine;
using UnityEngine.Events;

public delegate void OnDeath();
public class Character : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] int health;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Collider2D collider;
    [HideInInspector] public UnityEvent<int, int> OnHealthChanged;
    int _maxHealth;
    OnDeath _onDeath;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public Rigidbody2D Rigidbody
    {
        get { return rigidbody; }
    }
    public Collider2D Collider
    {
        get { return collider; }
    }
    public int MaxHealth
    {
        get { return _maxHealth; }
        protected set { _maxHealth = value; }
    }
    protected OnDeath OnDeath
    {
        get { return _onDeath; }
        set { _onDeath = value; }
    }

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
    public void Heal(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, _maxHealth);
    }
    public void Die()
    {
        OnDeath();
    }
}
