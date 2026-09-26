using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof (Character))]
public class Health : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] int health;
    public int Current => health;
    public int Max => _maxHealth;
    int _maxHealth;
    Character _character;

    void Awake()
    {
        _maxHealth = health;
        _character = GetComponent<Character>();
    }
 
    /// <summary>
    /// Subtracts amount from the character health. If it reaches zero, invokes Die().
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, _maxHealth);

        if (health <= 0)
        {
            _character.Die();
        }

        if (_character is Player)
        {
            GameEvents.RaiseHealthChanged(health, _maxHealth);
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
}
